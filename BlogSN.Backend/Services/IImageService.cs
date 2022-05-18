namespace BlogSN.Backend.Services;

public interface IImageService
{
    public Task<string> SaveImage(IFormFile imageFile, CancellationToken cancellationToken);

    public void DeleteImage(string imageName, CancellationToken cancellationToken);
}