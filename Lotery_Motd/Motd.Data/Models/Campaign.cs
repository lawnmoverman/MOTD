using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string MOTD { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TimeToClick { get; set; }

        public virtual List<Box> Boxes { get; set; }
        public virtual List<User> ActiveUsers { get; set; }
        public virtual List<CampaignLogItem> CampaignLogs { get; set; }
    }
}
