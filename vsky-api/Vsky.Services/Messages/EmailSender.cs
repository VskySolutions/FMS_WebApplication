using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Vsky.Core.Infrastructure;
using Vsky.Models;
using Vsky.Services.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Globalization;
using System.Net.Mail;

namespace Vsky.Services.Messages
{
    public partial class EmailSender : IEmailSender
    {
        #region Fields

        private readonly IAppFileProvider _fileProvider;
        private readonly ISmtpBuilder _smtpBuilder;

        #endregion

        #region Ctor

        public EmailSender(IAppFileProvider fileProvider, ISmtpBuilder smtpBuilder)
        {
            _fileProvider = fileProvider;
            _smtpBuilder = smtpBuilder;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Create an file attachment for the specific file path
        /// </summary>
        /// <param name="filePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a leaf-node MIME part that contains an attachment.
        /// </returns>
        private async Task<MimePart> CreateMimeAttachmentAsync(string filePath, string attachmentFileName = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (string.IsNullOrWhiteSpace(attachmentFileName))
            {
                attachmentFileName = Path.GetFileName(filePath);
            }

            return CreateMimeAttachment(attachmentFileName, await _fileProvider.ReadAllBytesAsync(filePath), _fileProvider.GetCreationTime(filePath),
                _fileProvider.GetLastWriteTime(filePath), _fileProvider.GetLastAccessTime(filePath));
        }

        /// <summary>
        /// Create an file attachment for the binary data
        /// </summary>
        /// <param name="attachmentFileName">Attachment file name</param>
        /// <param name="binaryContent">The array of unsigned bytes from which to create the attachment stream.</param>
        /// <param name="cDate">Creation date and time for the specified file or directory</param>
        /// <param name="mDate">Date and time that the specified file or directory was last written to</param>
        /// <param name="rDate">Date and time that the specified file or directory was last access to.</param>
        /// <returns>A leaf-node MIME part that contains an attachment.</returns>
        private static MimePart CreateMimeAttachment(string attachmentFileName, byte[] binaryContent, DateTime cDate, DateTime mDate, DateTime rDate)
        {
            if (!ContentType.TryParse(MimeTypes.GetMimeType(attachmentFileName), out var mimeContentType))
            {
                mimeContentType = new ContentType("application", "octet-stream");
            }

            return new MimePart(mimeContentType)
            {
                FileName = attachmentFileName,
                Content = new MimeContent(new MemoryStream(binaryContent)),
                ContentDisposition = new ContentDisposition
                {
                    CreationDate = cDate,
                    ModificationDate = mDate,
                    ReadDate = rDate
                },
                ContentTransferEncoding = ContentEncoding.Base64
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAccount">Email account to use</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="fromAddress">From address</param>
        /// <param name="fromName">From display name</param>
        /// <param name="toAddress">To address</param>
        /// <param name="toName">To display name</param>
        /// <param name="replyTo">ReplyTo address</param>
        /// <param name="replyToName">ReplyTo display name</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses list</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <param name="attachedDownloadId">Attachment download ID (another attachment)</param>
        /// <param name="headers">Headers</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SendEmailAsync(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName = null,
            string replyTo = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            List<string> attachmentFilePathList = null, List<string> attachmentFileNameList = null, string unSubscribeUrl=null,
            IDictionary<string, string> headers = null)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(fromName, fromAddress));
            message.To.Add(new MailboxAddress(toName, toAddress));

            if (!string.IsNullOrEmpty(replyTo))
            {
                message.ReplyTo.Add(new MailboxAddress(replyToName, replyTo));
            }

            // bcc
            if (bcc != null)
            {
                foreach (var address in bcc.Where(bccValue => !string.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(new MailboxAddress("", address.Trim()));
                }
            }

            // cc
            if (cc != null)
            {
                foreach (var address in cc.Where(ccValue => !string.IsNullOrWhiteSpace(ccValue)))
                {
                    message.Cc.Add(new MailboxAddress("", address.Trim()));
                }
            }

            // content
            message.Subject = subject;

            // headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }
            }

            // Add the List-Unsubscribe header
            //if(unSubscribeUrl!=null && unSubscribeUrl != "")
            //{
            //    var unsubscribeMailto = "mailto:" + toAddress + "?subject=" + unSubscribeUrl; // Replace with your actual unsubscribe mailto
            //    message.Headers.Add("List-Unsubscribe", $"<{unSubscribeUrl}>, <{unsubscribeMailto}>");
            //}            

            // Create a multipart/mixed MIME entity
            var multipart = new Multipart("mixed")
            {
                new TextPart(TextFormat.Html) { Text = body }
            };

            //Attach files from URLs
            var APIDOMAIN = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["API_Domain"];
            if (attachmentFilePathList != null)
            {
                foreach (var path in attachmentFilePathList)
                {
                    using (var client = new HttpClient())
                    {
                        var url = APIDOMAIN + path;
                        var response = await client.GetAsync(url);

                        // Check if the response status code is a success status code (2xx)
                        if (response.IsSuccessStatusCode)
                        {
                            using (var webClient = new WebClient())
                            {
                                byte[] data = await webClient.DownloadDataTaskAsync(url);
                                var attachment = new MimePart("application", "octet-stream")
                                {
                                    Content = new MimeContent(new MemoryStream(data)),
                                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                                    ContentTransferEncoding = ContentEncoding.Base64,
                                    FileName = Path.GetFileName(url) // Get the filename from the URL
                                };
                                multipart.Add(attachment);
                            }
                        }
                    }
                }
            }

            message.Body = multipart;

            // send email
            using (var smtpClient = await _smtpBuilder.BuildAsync(emailAccount))
            {
                await smtpClient.SendAsync(message);

                await smtpClient.DisconnectAsync(true);
            }
        }


        public virtual async Task SendMultipleEmailAtOnceAsync(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, List<string> toAddressList, string toName = null,
            string replyTo = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            List<string> attachmentFilePathList = null, List<string> attachmentFileNameList = null,
            IDictionary<string, string> headers = null)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(fromName, fromAddress));
            
            //Add multiple TO emails ids
            foreach (var toAddress in toAddressList)
            {
                message.To.Add(new MailboxAddress(toName, toAddress));
            }

            if (!string.IsNullOrEmpty(replyTo))
            {
                message.ReplyTo.Add(new MailboxAddress(replyToName, replyTo));
            }

            // bcc
            if (bcc != null)
            {
                foreach (var address in bcc.Where(bccValue => !string.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(new MailboxAddress("", address.Trim()));
                }
            }

            // cc
            if (cc != null)
            {
                foreach (var address in cc.Where(ccValue => !string.IsNullOrWhiteSpace(ccValue)))
                {
                    message.Cc.Add(new MailboxAddress("", address.Trim()));
                }
            }

            // content
            message.Subject = subject;

            // headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }
            }

            var multipart = new Multipart("mixed")
            {
                new TextPart(TextFormat.Html) { Text = body }
            };

            // create the file attachment for this e-mail message

            //if (!string.IsNullOrEmpty(attachmentFilePath) && _fileProvider.FileExists(attachmentFilePath))
            //{
            //    multipart.Add(await CreateMimeAttachmentAsync(attachmentFilePath, attachmentFileName));
            //}

            message.Body = multipart;

            // send email
            using (var smtpClient = await _smtpBuilder.BuildAsync(emailAccount))
            {
                await smtpClient.SendAsync(message);

                await smtpClient.DisconnectAsync(true);
            }
        }


        #endregion
    }
}