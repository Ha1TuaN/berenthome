using System.Text;
using System.Text.RegularExpressions;
using TD.KCN.WebApi.Application.House.FeatureHousess;
using TD.KCN.WebApi.Application.House.ImageHouses;
using TD.KCN.WebApi.Domain.Common.Events;
using TD.KCN.WebApi.Domain.House;

namespace TD.KCN.WebApi.Application.House.Motels;

public class CreateMotelRequest : IRequest<Result<Guid>>
{
    public string Title { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Type { get; set; } = default!;
    public Guid ProvinceId { get; set; }
    public Guid DistrictId { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    public decimal? Price { get; set; }
    public decimal? Area { get; set; }
    public int BedroomCount { get; set; }
    public int BathroomCount { get; set; }
    public List<CreateImageHouseRequest>? ImageHouseRequests { get; set; }
    public List<CreateFeatureHousesRequest>? FeatureHouseRequests { get; set; }

}

public class CreateMotelRequestValidator : CustomValidator<CreateMotelRequest>
{
    public CreateMotelRequestValidator(IReadRepository<Motel> repository, IStringLocalizer<CreateMotelRequestValidator> localizer)
    {

    }

}

public class CreateMotelRequestHandler : IRequestHandler<CreateMotelRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Motel> _repository;
    private readonly IStringLocalizer<CreateMotelRequestHandler> _localizer;

    public CreateMotelRequestHandler(IRepositoryWithEvents<Motel> repository, IStringLocalizer<CreateMotelRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(CreateMotelRequest request, CancellationToken cancellationToken)
    {
        var motel = new Motel(
            request.Title,
            request.Address,
            request.Type,
            request.ProvinceId,
            request.DistrictId,
            request.Description,
            request.UserId,
            request.Price,
            request.Area,
            request.BedroomCount,
            request.BathroomCount);
        await _repository.AddAsync(motel, cancellationToken);

        return Result<Guid>.Success(motel.Id);
    }
}