namespace BlogSN.Backend.Services;

public class ImageService: IImageService
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public ImageService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
    
    public async Task<string> SaveImage(IFormFile imageFile, CancellationToken cancellationToken)
    {
        string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
        imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
        var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }
        return imageName;
    }
    
    public void DeleteImage(string imageName, CancellationToken cancellationToken)
    {
        var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
        if (System.IO.File.Exists(imagePath))
            System.IO.File.Delete(imagePath);
    }
}