using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Transmission : Entity
    {
        public Transmission() { }
        public Transmission(int id, string? name) : base(id)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
