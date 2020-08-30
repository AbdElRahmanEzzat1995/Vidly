using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType  { get; set; }
        public byte MembershipTypeId { get; set; }
        public String Birthdate { get; set; }
    }
}