namespace TD.KCN.WebApi.Application.House.Motels;

public class MotelDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Star { get; set; }
    public string Address { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Guid ProvinceId { get; set; }
    public string? ProvinceName { get; set; }
    public Guid DistrictId { get; set; }
    public string? DistrictName { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    public decimal? Price { get; set; }
    public decimal? Area { get; set; }
    public int? BedroomCount { get; set; }
    public int? BathroomCount { get; set; }
}