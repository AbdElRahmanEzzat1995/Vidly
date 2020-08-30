using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }

        
        [Required]
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}