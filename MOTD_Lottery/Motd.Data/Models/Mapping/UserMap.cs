using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(40);
            this.Property(t => t.LastName)
                .HasMaxLength(40);
            this.Property(t => t.Email)
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Birthday).HasColumnName("Birthday");            
            this.Property(t => t.IsFbUser).HasColumnName("IsFbUser");            
         }
    }
}
