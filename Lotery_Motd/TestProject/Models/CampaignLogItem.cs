using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class CampaignLogItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public System.DateTime LogTime { get; set; }
        public bool isCorrectMotd { get; set; }
        public bool isWonAPrize { get; set; }
        public Nullable<int> Campaign_Id { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual User User { get; set; }
    }
}
