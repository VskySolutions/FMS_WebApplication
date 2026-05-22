using System;

namespace Vsky.Api.Models
{
    public record TokenModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public record TokenResultModel
    {
        public string Token { get; set; }

        public int ExpiresIn { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string[] Roles { get; set; }

        public string CompanyName { get; set; }

        public string ProfilePictureId { get; set; }

        public string CompanyLogoId { get; set; }
        
    }

    public record RegisterModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public record ChangePasswordModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
        
    }

    public record ForgotPasswordModel
    {
        public string Email { get; set; }
    }
}