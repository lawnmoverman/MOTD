using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Web.Models.ViewModels
{
    public class PrizeViewModel
    {        
        public int Id { get; set; }     
        public string Name { get; set; }      
        public string Description { get; set; }       
        public bool IsWon { get; set; }        
    }
}
