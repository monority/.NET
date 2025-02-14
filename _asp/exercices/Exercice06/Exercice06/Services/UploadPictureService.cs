
namespace Exercice06.Services;

public class UploadPictureService : IUploadPictureService
{
    private readonly IWebHostEnvironment _webHost;

    public UploadPictureService(IWebHostEnvironment webHost)
    {
        _webHost = webHost;
    }
    public string Upload(IFormFile file)
    {
        if (file == null || file.Length == 0) return null;

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        var pathToSave = Path.Combine(_webHost.WebRootPath, "pictures", fileName);

        using var fileStream = new FileStream(pathToSave, FileMode.Create);
        file.CopyTo(fileStream);

        return $"/pictures/{fileName}";
    }
}
