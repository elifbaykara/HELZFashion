using HELZFashion.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Persistence.Configurations.Identity
{
    public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            builder.HasOne<User>(x => x.User)
                .WithOne(u => u.UserSetting)
                .HasForeignKey<UserSetting>(us => us.UserId);

            builder.Property(x => x.CreatedOn).IsRequired();

            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);


            builder.Property(x => x.ModifiedOn).IsRequired(false);

            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);


            builder.Property(x => x.DeletedOn).IsRequired(false);

            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

            builder.ToTable("UserSettings");
        }
    }
}
