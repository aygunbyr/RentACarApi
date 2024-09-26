using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public sealed class Transmission : Entity<int>
    {
        public Transmission() { }
        public Transmission(int id, string name) : base(id)
        {
            Name = name;
        }
        [Required]
        public string Name { get; set; }
    }
}
