using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Fuel : Entity
    {
        public Fuel() { }
        public Fuel(int id, string? name) : base(id)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
