using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public class Transmission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
