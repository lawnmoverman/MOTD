using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models.Mapping
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
            this.Property(t => t.LogTime).HasColumnName("LogTime");
                        
            
        }
    }
}
