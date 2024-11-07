using TD.KCN.WebApi.Application.Common.Minio;
using TD.KCN.WebApi.Host.Controllers;

namespace TD.KCN.WebApi.Host.Controllers.Minio;

public class MiniosController : VersionNeutralApiController
{
    private readonly IMinioService _minioService;

    public MiniosController(IMinioService minioService) => _minioService = minioService;

    [HttpPost("upload")]
    ////[MustHavePermission(TDAction.Create, TDResource.Minios)]
    [OpenApiOperation("upload file.", "")]
    public Task<List<AttachmentResponse>> UploadFiles(List<IFormFile> files, CancellationToken cancellationToken)
    {
        return _minioService.UploadFilesAsync(files, string.Empty, string.Empty, cancellationToken);
    }
}
