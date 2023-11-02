using Avalonia.Media.Imaging;

namespace HelloAvalonia.Models;

public class CatsImageService : ICatsImageService
{
    private readonly HttpClient _httpClient;

    public CatsImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Bitmap> GetRandomImage()
    {
        var bytes = await _httpClient.GetByteArrayAsync("https://cataas.com/cat");
        return new Bitmap(new MemoryStream(bytes));
    }
}