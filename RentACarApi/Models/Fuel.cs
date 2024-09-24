using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public class Fuel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
