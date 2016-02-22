using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models.Mapping
{
    public class BoxMap : EntityTypeConfiguration<Box>
    {
        public BoxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Box");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.isEmpty).HasColumnName("isEmpty");           
              
        }
    }
}
 