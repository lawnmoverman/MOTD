using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class Box
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsEmpty { get; set; }
        public Nullable<int> Campaign_Id { get; set; }
        public Nullable<int> Prize_Id { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Prize Prize { get; set; }
    }
}
