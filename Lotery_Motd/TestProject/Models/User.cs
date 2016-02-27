using System;
using System.Collections.Generic;

namespace TestProject.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }
        public bool IsFbUser { get; set; }
        public Nullable<int> Campaign_Id { get; set; }
        public virtual AdminLogItem AdminLogItem { get; set; }
        public virtual CampaignLogItem CampaignLogItem { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
