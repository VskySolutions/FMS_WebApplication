using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vsky.Models;

namespace Vsky.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<ActivityLogType> ActivityLogTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        
        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<DropDown> DropDowns { get; set; }
        public virtual DbSet<DropDownType> DropDownTypes { get; set; }
        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecords { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<PictureBinary> PictureBinaries { get; set; }
        
        public virtual DbSet<QueuedEmail> QueuedEmails { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
       
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        
        public virtual DbSet<ApplicationUserInfo> ApplicationUserInfo { get; set; }
        public virtual DbSet<ApplicationUserParent> ApplicationUserParent { get; set; }
                
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                        

            builder.Entity<ActivityLogType>(entity =>
            {
                entity.ToTable("ActivityLogType");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.SystemKeyword).IsRequired().HasMaxLength(100);
            });


            builder.Entity<ApplicationUserParent>(entity =>
            {
                entity.ToTable("AspNetUsersParent");
                entity.Property(e => e.StudentId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.ParentId).IsRequired().HasMaxLength(450);
            });

            builder.Entity<ApplicationUserInfo>(entity =>
            {
                entity.ToTable("AspNetUserInfo");
                entity.Property(e => e.UserId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.JackrabbitUserId);               
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            });

            builder.Entity<MenuPermission>(entity =>
            {
                entity.ToTable("MenuPermissions");

                entity.Property(e => e.MenuId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.RoleId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.IsManage);
                entity.Property(e => e.IsView);
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            });

            builder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menus");
                entity.Property(e => e.ModuleId).HasMaxLength(450);
                entity.Property(e => e.MenuName).IsRequired().HasMaxLength(128);
                entity.Property(e => e.DisplayName).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Link).HasMaxLength(900); 
                entity.Property(e => e.Sortorder).IsRequired();
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
                
                entity.Property(e => e.ParentMenuId).HasMaxLength(450);

            });

            builder.Entity<ActivityLog>(entity =>
            {
                entity.ToTable("ActivityLog");

                entity.Property(e => e.ActivityLogTypeId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.Comment).IsRequired();
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
                entity.Property(e => e.EntityId).HasMaxLength(450);
                entity.Property(e => e.EntityName).HasMaxLength(400);
                entity.Property(e => e.IpAddress).HasMaxLength(200);
                entity.Property(e => e.UserId).IsRequired().HasMaxLength(450);

                entity.HasOne(d => d.ActivityLogType).WithMany(p => p.ActivityLogs).HasForeignKey(d => d.ActivityLogTypeId);
                entity.HasOne(d => d.User).WithMany(p => p.ActivityLogs).HasForeignKey(d => d.UserId);
            });

            builder.Entity<ApplicationUser>(b =>
            {
                b.Property(e => e.ProfilePictureId).HasMaxLength(450);

                b.HasMany(e => e.Claims).WithOne(e => e.User).HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany(e => e.Logins).WithOne(e => e.User).HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany(e => e.Tokens).WithOne(e => e.User).HasForeignKey(ut => ut.UserId).IsRequired();
                b.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(ur => ur.UserId).IsRequired();             
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany(e => e.RoleClaims).WithOne(e => e.Role).HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<ApplicationUserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<EmailAccount>(entity =>
            {
                entity.ToTable("EmailAccount");
                entity.Property(e => e.DisplayName).HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Host).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(255);
            });

            builder.Entity<MessageTemplate>(entity =>
            {
                entity.ToTable("MessageTemplate");
                entity.Property(e => e.BccEmailAddresses).HasMaxLength(200);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Subject).HasMaxLength(1000);
            });

            builder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Value).IsRequired().HasMaxLength(2000);
            });

            builder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
                entity.Property(e => e.IpAddress).HasMaxLength(200);
                entity.Property(e => e.ShortMessage).IsRequired();

                entity.Ignore(e => e.LogLevel);

                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            });

            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);
                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            });

            builder.Entity<Download>(entity =>
            {
                entity.ToTable("Download");
            });

            builder.Entity<DropDown>(entity =>
            {
                entity.ToTable("DropDown");

                entity.Property(e => e.CreatedById).IsRequired().HasMaxLength(450);
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
                entity.Property(e => e.DropDownTypeId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.DropDownValue).IsRequired().HasMaxLength(128);
                entity.Property(e => e.UpdatedById).HasMaxLength(450);
                entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);

                entity.HasOne(d => d.DropDownType).WithMany().HasForeignKey(d => d.DropDownTypeId);
            });

            builder.Entity<DropDownType>(entity =>
            {
                entity.ToTable("DropDownType");

                entity.Property(e => e.Type).IsRequired().HasMaxLength(128);
            });

           
            builder.Entity<PermissionRecord>(entity =>
            {
                entity.ToTable("PermissionRecord");

                entity.Property(e => e.Category).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.SystemName).IsRequired().HasMaxLength(255);

                entity.HasMany(d => d.Roles).WithMany(p => p.PermissionRecords)
                    .UsingEntity<Dictionary<string, object>>(
                        "PermissionRecordRoleMapping",
                        r => r.HasOne<ApplicationRole>().WithMany().HasForeignKey("RoleId"),
                        l => l.HasOne<PermissionRecord>().WithMany().HasForeignKey("PermissionRecordId"),
                        j =>
                        {
                            j.HasKey("PermissionRecordId", "RoleId");
                            j.ToTable("PermissionRecord_Role_Mapping");
                            j.HasIndex(new[] { "PermissionRecordId" }, "IX_PermissionRecord_Role_Mapping_PermissionRecord_Id");
                            j.HasIndex(new[] { "RoleId" }, "IX_PermissionRecord_Role_Mapping_Role_Id");
                            j.IndexerProperty<string>("PermissionRecordId").HasColumnName("PermissionRecord_Id");
                            j.IndexerProperty<string>("RoleId").HasColumnName("Role_Id");
                        });
            });

            builder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.MimeType).IsRequired();
                entity.Property(e => e.SeoFilename);
            });

            builder.Entity<PictureBinary>(entity =>
            {
                entity.ToTable("PictureBinary");

                entity.Property(e => e.PictureId).IsRequired();
            });

           
            builder.Entity<QueuedEmail>(entity =>
            {
                entity.ToTable("QueuedEmail");

                entity.Property(e => e.AttachedDownloadId).HasMaxLength(450);
                entity.Property(e => e.Bcc).HasMaxLength(500);
                entity.Property(e => e.Cc).HasMaxLength(500);
                entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
                entity.Property(e => e.DontSendBeforeDateUtc).HasPrecision(6);
                entity.Property(e => e.EmailAccountId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.From).IsRequired().HasMaxLength(500);
                entity.Property(e => e.FromName).HasMaxLength(500);
                entity.Property(e => e.ReplyTo).HasMaxLength(500);
                entity.Property(e => e.ReplyToName).HasMaxLength(500);
                entity.Property(e => e.SentOnUtc).HasPrecision(6);
                entity.Property(e => e.Subject).HasMaxLength(1000);
                entity.Property(e => e.To).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ToName).HasMaxLength(500);
            });

            builder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ReferenceId).HasMaxLength(450);
                entity.Property(e => e.Value).IsRequired();
            });

            builder.Entity<StateProvince>(entity =>
            {
                entity.ToTable("StateProvince");

                entity.Property(e => e.Abbreviation).HasMaxLength(100);
                entity.Property(e => e.CountryId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.HasOne(d => d.Country).WithMany(p => p.StateProvinces).HasForeignKey(d => d.CountryId);
            });
                        
        }
    }
}