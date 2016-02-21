using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Data.Models.Mapping
{
    public class AdminLogItemMap : EntityTypeConfiguration<AdminLogItem>
    {
        public AdminLogItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdminLogItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LogTime).HasColumnName("LogTime");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany()
                .HasForeignKey(d => d.UserId); 
        }
    }
}
