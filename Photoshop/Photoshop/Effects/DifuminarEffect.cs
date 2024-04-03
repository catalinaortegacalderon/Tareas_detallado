using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public class Difuminar:IPhotoEffect
{
    private readonly string _description = "Difumina la imagen.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> NewImage = new Image<Rgb24>(width, height); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int r = originalImage[x, y].R;
                int g = originalImage[x, y].G;
                int b = originalImage[x, y].B;
                Byte r2 = (Byte)(255);
                Byte g2 = (Byte)(255);
                Byte b2 = (Byte)(255);
                if (r < 235)
                {
                    r2 = (Byte)(r + 20);
                }
                if (g < 235)
                {
                    g2 = (Byte)(g + 20);
                }
                if (b < 235)
                {
                    b2 = (Byte)(b + 20);
                }
                NewImage[x, y] = new Rgb24(r2,g2,b2);
            }   
        }

        return NewImage;
    }
}