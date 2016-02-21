using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class AdminLogItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime LogTime { get; set; }
        public virtual User User { get; set; }
        
    }
}
