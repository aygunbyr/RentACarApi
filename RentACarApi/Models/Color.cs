using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Color : Entity<int>
    {
        public Color() { }
        public Color(int id, string name) : base(id)
        {
            Name = name;
        }
        [Required]
        public string Name { get; set; }
    }
}
