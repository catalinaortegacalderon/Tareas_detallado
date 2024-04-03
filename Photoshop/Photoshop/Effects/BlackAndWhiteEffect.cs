using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public class BlackAndWhiteEffect:IPhotoEffect
{
    private readonly string _description = "Cambia la foto a blanco y negro.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> blackAndWhiteImage = new Image<Rgb24>(width, height); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int r = originalImage[x, y].R;
                int g = originalImage[x, y].G;
                int b = originalImage[x, y].B;
                Byte averageColor = (Byte)((r+g+b) / 3);
                blackAndWhiteImage[x, y] = new Rgb24(averageColor,averageColor,averageColor);
            }   
        }

        return blackAndWhiteImage;
    }
}