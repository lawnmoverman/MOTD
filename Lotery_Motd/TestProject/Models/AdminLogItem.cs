using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class AdminLogItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public System.DateTime LogTime { get; set; }
        public virtual User User { get; set; }
    }
}
