using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public GenreTypes GenreType { get; set; }

        [Required]
        public int GenreTypeId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        public int? NumberInStock { get; set; }
        
    }
}