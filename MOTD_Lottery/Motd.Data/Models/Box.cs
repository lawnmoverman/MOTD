using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class Box
    {
        public int Id { get; set; }
        public bool isEmpty { get; set; } 
        public Nullable<int> PrizeId { get; set; }        
        public virtual Prize Prize { get; set; }        
    }
}
