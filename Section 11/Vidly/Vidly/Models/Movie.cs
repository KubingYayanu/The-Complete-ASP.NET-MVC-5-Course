using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Attributes;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number Avaliable")]
        [Range(1, 20)]
        public byte NumberAvaliable { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [DecimalPrecision(18, 2)]
        [Range(0, 1)]
        public decimal Discount { get; set; }
    }
}