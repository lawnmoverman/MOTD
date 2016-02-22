using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Motd.Classes.Models
{
    public class Box
    {
        [Key, ForeignKey("Prize")]
        public int Id { get; set; }
        public string Description { get; set; }   
        public bool isEmpty { get; set; }                
        public virtual Prize Prize { get; set; }
        public virtual Campaign Campaign { get; set; } 
    }
}
