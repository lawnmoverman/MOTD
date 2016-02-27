using Motd.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Data
{
    public class MotdContext : DbContext
    {        
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignLogItem> CampaignLogs{ get; set; }
        public DbSet<AdminLogItem> AdminLogs { get; set; }
    }
}
