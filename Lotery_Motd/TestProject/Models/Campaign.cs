using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            this.Boxes = new List<Box>();
            this.CampaignLogItems = new List<CampaignLogItem>();
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MOTD { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TimeToClick { get; set; }
        public virtual ICollection<Box> Boxes { get; set; }
        public virtual ICollection<CampaignLogItem> CampaignLogItems { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
