using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class AdminLogItem
    {
        [Key,  DatabaseGenerated(DatabaseGeneratedOption.Identity), ForeignKey("User")]        
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public DateTime LogTime { get; set; }

        public virtual User User { get; set; }
        
    }
}
