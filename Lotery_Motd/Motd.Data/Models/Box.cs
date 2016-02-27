using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class Box
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; } 
        [Required]
        public bool IsEmpty { get; set; } 
        
        //public virtual Campaign Campaign { get; set; }

        public virtual Prize Prize { get; set; }
    }
}
