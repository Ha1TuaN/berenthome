using System.Xml.Linq;

namespace TD.KCN.WebApi.Domain.House;
public class Motel : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; } = default!;
    public string? Star { get; set; }
    public string Address { get; set; } = default!;
    public string Type { get; set; } = default!;
    public Guid ProvinceId { get; set; }
    public virtual Area? Province { get; set; }
    public Guid DistrictId { get; set; }
    public virtual Area? District { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    public decimal? Price { get; set; } = default!;
    public decimal? Area { get; set; } = default!;
    public int BedroomCount { get; set; } = default!;
    public int BathroomCount { get; set; } = default!;

    public Motel(
        string title,
        string address,
        string type,
        Guid provinceId,
        Guid districtId,
        string? description,
        string? userId,
        decimal? price,
        decimal? area,
        int bedroomCount,
        int bathroomCount
    )
    {
        Title = title;
        Address = address;
        Type = type;
        ProvinceId = provinceId;
        DistrictId = districtId;
        Description = description;
        UserId = userId;
        Price = price;
        Area = area;
        BedroomCount = bedroomCount;
        BathroomCount = bathroomCount;
    }

    public Motel Update(
        string? title,
        string? address,
        string? type,
        Guid? provinceId,
        Guid? districtId,
        string? desciption,
        decimal? price,
        decimal? area,
        int? bedroomCount,
        int? bathroomCount)
    {
        Title = title ?? Title;
        Address = address ?? Address;
        Type = type ?? Type;
        ProvinceId = provinceId ?? ProvinceId;
        DistrictId = districtId ?? DistrictId;
        Description = desciption ?? Description;
        Price = price ?? Price;
        Area = area ?? Area;
        BedroomCount = bedroomCount ?? BedroomCount;
        BathroomCount = bathroomCount ?? BathroomCount;

        return this;
    }
}
