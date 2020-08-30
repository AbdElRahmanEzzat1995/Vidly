using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public String Name { get; set; }

        [Required]
        public short SignUpFee { get; set; }

        [Required]
        public byte DurationInMonths { get; set; }

        [Required]
        public byte DiscountRate { get; set; }

        public static readonly byte UnKnown = 0;

        public static readonly byte PayAsYouGo = 1;
    }
}