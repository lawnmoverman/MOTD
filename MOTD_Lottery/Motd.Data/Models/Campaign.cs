using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class Campaign
    {
        public Campaign()
        {
            this.Boxes = new List<Box>();
            this.ActiveUsers = new List<User>();
            this.CampaignLogs = new List<CampaignLogItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MOTD { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeToClick { get; set; }

        public IEnumerable<Box> Boxes { get; set; }
        public IEnumerable<User> ActiveUsers { get; set; }
        public IEnumerable<CampaignLogItem> CampaignLogs { get; set; }
    }
}
