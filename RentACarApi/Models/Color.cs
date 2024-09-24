using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Color : Entity
    {
        public Color() { }
        public Color(int id, string? name) : base(id)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
