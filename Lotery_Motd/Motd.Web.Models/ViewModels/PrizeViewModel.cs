using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Motd.Web.Models.ViewModels
{
    public class PrizeViewModel
    {            
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        public bool IsWon { get; set; }        
    }
}
