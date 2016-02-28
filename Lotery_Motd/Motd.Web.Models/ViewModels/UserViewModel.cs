using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Web.Models.ViewModels
{
    public class UserViewModel
    {      
        public int Id { get; set; }       
        public string Name { get; set; }      
        public string LastName { get; set; }       
        public string Email { get; set; }       
        public DateTime Birthday { get; set; }       
        public bool IsFbUser { get; set; }
    }
}
