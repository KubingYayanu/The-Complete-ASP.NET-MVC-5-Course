using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number Avaliable")]
        [Range(1, 20)]
        public byte? NumberAvaliable { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        [RegularExpression(@"^(([0]{1})|([0-9]{1,11}))(\.([0-9]{1,2}))?$", ErrorMessage = "Invalid Discount")]
        [Range(0, 1)]
        public decimal? Discount { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            NumberAvaliable = movie.NumberAvaliable;
            Price = movie.Price;
            Discount = movie.Discount;
        }
    }
}