using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class PrizeMap : EntityTypeConfiguration<Prize>
    {
        public PrizeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Prizes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsWon).HasColumnName("IsWon");
        }
    }
}
