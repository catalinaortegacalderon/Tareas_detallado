using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public class ReflejarEffect:IPhotoEffect
{
    private readonly string _description = "Refleja la imagen.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> NewImage = new Image<Rgb24>(width, height); 
        //Console.WriteLine(width);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Byte r = originalImage[x, y].R;
                Byte g = originalImage[x, y].G;
                Byte b = originalImage[x, y].B;
                //Console.WriteLine(width);
                NewImage[width - x - 1, y] = new Rgb24(r,g,b);
            }   
        }

        return NewImage;
    }
}