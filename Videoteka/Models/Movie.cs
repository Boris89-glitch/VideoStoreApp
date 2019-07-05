using System;
using System.ComponentModel.DataAnnotations;

namespace Video_store_app.Models
{
    public class Movie
    {
        [Required(ErrorMessage = "You need to select the genre")]
        public int GenreId { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "Enter between 1 and 20 here.")]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
        public Genre Genre { get; set; }
    }
}