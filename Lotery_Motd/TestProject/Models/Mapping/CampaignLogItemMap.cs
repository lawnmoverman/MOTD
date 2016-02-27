using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class CampaignLogItemMap : EntityTypeConfiguration<CampaignLogItem>
    {
        public CampaignLogItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CampaignLogItems");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LogTime).HasColumnName("LogTime");
            this.Property(t => t.isCorrectMotd).HasColumnName("isCorrectMotd");
            this.Property(t => t.isWonAPrize).HasColumnName("isWonAPrize");
            this.Property(t => t.Campaign_Id).HasColumnName("Campaign_Id");

            // Relationships
            this.HasOptional(t => t.Campaign)
                .WithMany(t => t.CampaignLogItems)
                .HasForeignKey(d => d.Campaign_Id);
            this.HasRequired(t => t.User)
                .WithOptional(t => t.CampaignLogItem);

        }
    }
}
