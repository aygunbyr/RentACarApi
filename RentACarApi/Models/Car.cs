using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarApi.Models
{
    public sealed class Car : Entity
    {
        public Car(){}

        public Car(int id, int colorId, Color color, int fuelId, Fuel fuel, int transmissionId, Transmission transmission, string carState, int? kiloMeter, short? modelYear, string? plate, string? brandName, string? modelName, double? dailyPrice) : base(id)
        {
            ColorId = colorId;
            Color = color;
            FuelId = fuelId;
            Fuel = fuel;
            TransmissionId = transmissionId;
            Transmission = transmission;
            CarState = carState;
            KiloMeter = kiloMeter;
            ModelYear = modelYear;
            Plate = plate;
            BrandName = brandName;
            ModelName = modelName;
            DailyPrice = dailyPrice;
        }

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
