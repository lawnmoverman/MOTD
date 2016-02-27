using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.IsFbUser).HasColumnName("IsFbUser");
            this.Property(t => t.Campaign_Id).HasColumnName("Campaign_Id");

            // Relationships
            this.HasOptional(t => t.Campaign)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.Campaign_Id);

        }
    }
}
