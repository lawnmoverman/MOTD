using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class BoxMap : EntityTypeConfiguration<Box>
    {
        public BoxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Boxes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsEmpty).HasColumnName("IsEmpty");
            this.Property(t => t.Campaign_Id).HasColumnName("Campaign_Id");
            this.Property(t => t.Prize_Id).HasColumnName("Prize_Id");

            // Relationships
            this.HasOptional(t => t.Campaign)
                .WithMany(t => t.Boxes)
                .HasForeignKey(d => d.Campaign_Id);
            this.HasOptional(t => t.Prize)
                .WithMany(t => t.Boxes)
                .HasForeignKey(d => d.Prize_Id);

        }
    }
}
