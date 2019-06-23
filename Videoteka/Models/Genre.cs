using System.ComponentModel.DataAnnotations;

namespace Video_store_app.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}