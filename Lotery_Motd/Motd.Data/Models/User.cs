using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Motd.Data.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]        
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public bool IsFbUser { get; set; }

        public virtual Campaign Campaign { get; set; } 
    }
}
