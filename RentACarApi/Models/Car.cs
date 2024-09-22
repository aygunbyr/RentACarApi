using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarApi.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        [Required]
        public int FuelId { get; set; }
        [ForeignKey("FuelId")]
        public Fuel Fuel { get; set; }
        [Required]
        public int TransmissionId { get; set; }
        [ForeignKey("TransmissionId")]
        public Transmission Transmission { get; set; }
        [Required]
        public string CarState { get; set; }
        public int? KiloMeter { get; set; }
        public short? ModelYear { get; set; }
        public string? Plate { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public double? DailyPrice { get; set; }
    }
}
