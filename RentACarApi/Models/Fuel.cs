using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Fuel : Entity<int>
    {
        public Fuel() { }
        public Fuel(int id, string name) : base(id)
        {
            Name = name;
        }
        [Required]
        public string Name { get; set; }
    }
}
