using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestProject.Models.Mapping;

namespace TestProject.Models
{
    public partial class motdContext : DbContext
    {
        static motdContext()
        {
            Database.SetInitializer<motdContext>(null);
        }

        public motdContext()
            : base("Name=motdContext")
        {
        }

        public DbSet<AdminLogItem> AdminLogItems { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<CampaignLogItem> CampaignLogItems { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminLogItemMap());
            modelBuilder.Configurations.Add(new BoxMap());
            modelBuilder.Configurations.Add(new CampaignLogItemMap());
            modelBuilder.Configurations.Add(new CampaignMap());
            modelBuilder.Configurations.Add(new PrizeMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
