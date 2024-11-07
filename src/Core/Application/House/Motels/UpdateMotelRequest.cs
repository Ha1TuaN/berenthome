using Mapster;
using System.Text;
using System.Text.RegularExpressions;
using TD.KCN.WebApi.Domain.House;

namespace TD.KCN.WebApi.Application.House.Motels;

public class UpdateMotelRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }
    public string? Type { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? Area { get; set; }
    public decimal? Motel { get; set; }
    public int? BedroomCount { get; set; }
    public int? BathroomCount { get; set; }
}

public class UpdateMotelRequestValidator : CustomValidator<UpdateMotelRequest>
{
    public UpdateMotelRequestValidator(IRepository<Motel> repository, IStringLocalizer<UpdateMotelRequestValidator> localizer)
    {

    }

}

public class UpdateMotelRequestHandler : IRequestHandler<UpdateMotelRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Motel> _repository;
    private readonly IStringLocalizer<UpdateMotelRequestHandler> _localizer;

    public UpdateMotelRequestHandler(IRepositoryWithEvents<Motel> repository, IStringLocalizer<UpdateMotelRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateMotelRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Motel.notfound"], request.Id));

        item.Update(
            request.Title,
            request.Address,
            request.Type,
            request.ProvinceId,
            request.DistrictId,
            request.Description,
            request.Price,
            request.Area,
            request.BedroomCount,
            request.BathroomCount);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }

}