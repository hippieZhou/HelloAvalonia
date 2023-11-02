using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace HelloAvalonia.Models;

public interface ICatsImageService
{
    Task<Bitmap> GetRandomImage();
}