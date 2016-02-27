using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class CampaignMap : EntityTypeConfiguration<Campaign>
    {
        public CampaignMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MOTD)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Campaigns");
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
