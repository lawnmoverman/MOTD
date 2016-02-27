using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestProject.Models.Mapping
{
    public class AdminLogItemMap : EntityTypeConfiguration<AdminLogItem>
    {
        public AdminLogItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("AdminLogItems");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LogTime).HasColumnName("LogTime");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.AdminLogItem);

        }
    }
}
