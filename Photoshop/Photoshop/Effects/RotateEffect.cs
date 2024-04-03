using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public class RotateEffect:IPhotoEffect
{
    private readonly string _description = "Rota la foto en 90 grados.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> RotatedImage = new Image<Rgb24>(height, width); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Byte r = originalImage[x, y].R;
                Byte g = originalImage[x, y].G;
                Byte b = originalImage[x, y].B;
                RotatedImage[height -y -1, x] = new Rgb24(r,g,b);
            }   
        }

        return RotatedImage;
    }
}