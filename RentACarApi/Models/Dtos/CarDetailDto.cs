namespace RentACarApi.Models.Dtos
{
    public record CarDetailDto(int Id,
                               string? FuelName,
                               string? TransmissionName,
                               string? ColorName,
                               string CarState,
                               int? KiloMeter,
                               short? ModelYear,
                               string? Plate,
                               string? BrandName,
                               string? ModelName,
                               double? DailyPrice);
}
