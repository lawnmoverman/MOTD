using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Prize
    {
        public Prize()
        {
            this.Boxes = new List<Box>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsWon { get; set; }
        public virtual ICollection<Box> Boxes { get; set; }
    }
}
