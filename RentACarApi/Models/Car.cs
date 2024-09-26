using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACarApi.Models
{
    public sealed class Car : Entity<long>
    {
        public Car() { }
        public Car(long id, int colorId, Color? color, int fuelId, Fuel? fuel, int transmissionId, Transmission? transmission, string carState, int? kiloMeter, short? modelYear, string? plate, string? brandName, string? modelName, double? dailyPrice) : base(id)
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

        [Required]
        public int ColorId { get; set; }

        [JsonIgnore]
        [ForeignKey("ColorId")]
        public Color? Color { get; set; }

        [Required]
        public int FuelId { get; set; }

        [JsonIgnore]
        [ForeignKey("FuelId")]
        public Fuel? Fuel { get; set; }

        [Required]
        public int TransmissionId { get; set; }

        [JsonIgnore]
        [ForeignKey("TransmissionId")]
        public Transmission? Transmission { get; set; }

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
