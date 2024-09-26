namespace RentACarApi.Models.Dtos
{
    public record CarDetailDto(long Id,
                               string? FuelName,
                               string? TransmissionName,
                               string? ColorName,
                               string CarState,
                               int? KiloMeter,
                               short? ModelYear,
                               string? Plate,
                               string? BrandName,
                               string? ModelName,
                               double? DailyPrice,
                               DateTime CreatedAt,
                               DateTime UpdatedAt);
}
