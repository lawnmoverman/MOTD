using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models
{
    public class AdminLogItem
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        public string Description { get; set; }        
        public DateTime LogTime { get; set; }
        public virtual User User { get; set; }
        
    }
}
