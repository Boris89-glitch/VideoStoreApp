using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class MembershipTypes
    {
        public short Fee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}