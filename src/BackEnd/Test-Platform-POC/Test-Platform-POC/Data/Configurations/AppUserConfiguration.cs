using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Test_Platform_POC.Domain.Models;

namespace Test_Platform_POC.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasComment($"{DateTime.Now} - This entity used for interaction IdentityServer");
            builder.HasKey(u => u.Id);
            builder.Ignore(u => u._Id);
            builder.Ignore(u => u.Busy);
            builder.Ignore(u => u.LastVisit);
            builder.HasIndex(u => u.Id);
            builder.HasIndex(u => u.UserName).IsUnique();
        }
    }
}
