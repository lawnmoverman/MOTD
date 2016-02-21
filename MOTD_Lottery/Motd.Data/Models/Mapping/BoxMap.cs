using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Data.Models.Mapping
{
    public class BoxMap : EntityTypeConfiguration<Box>
    {
        public BoxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
          

            // Table & Column Mappings
            this.ToTable("Box");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.isEmpty).HasColumnName("isEmpty");
            this.Property(t => t.PrizeId).HasColumnName("PrizeId");            

            // Relationships
            this.HasOptional(t => t.Prize)                
                .WithMany()
                .HasForeignKey(d => d.PrizeId);           
        }
    }
}
 