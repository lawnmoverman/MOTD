using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models.Mapping
{
    public class CampaignLogItemMap : EntityTypeConfiguration<CampaignLogItem>
    {
        public CampaignLogItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CampaignLogItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");            
            this.Property(t => t.LogTime).HasColumnName("LogTime");
            this.Property(t => t.isCorrectMotd).HasColumnName("isCorrectMotd");
            this.Property(t => t.isWonAPrize).HasColumnName("isWonAPrize");            
        }
            
    }
}
