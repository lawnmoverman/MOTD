using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models.Mapping
{
    public class CampaignMap:EntityTypeConfiguration<Campaign>
    {
        public CampaignMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(40);
            this.Property(t => t.Name)
                .HasMaxLength(40);
            this.Property(t => t.MOTD)
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("Campaign");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MOTD).HasColumnName("MOTD");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.StartDate).HasColumnName("StartDate");    
            this.Property(t => t.EndDate).HasColumnName("EndDate"); 
            this.Property(t => t.TimeToClick).HasColumnName("TimeToClick");
                       
         }
    }
}
