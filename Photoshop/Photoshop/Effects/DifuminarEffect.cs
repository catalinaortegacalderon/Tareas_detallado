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
                Byte r;
                Byte g;
                Byte b;
                //4 esquinas
                if (x == 0 && y == 0)
                {
                    r = (Byte)((originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x, y + 1].G + originalImage[x + 1, y + 1].G +
                                originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                else if (x == width - 1 && y == height - 1)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                else if (x == 0 && y == height - 1)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                else if (y == 0 && x == width - 1)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                //borde izq
                else if (x == 0)
                {
                    r = (Byte)((originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R + originalImage[x, y].R + originalImage[x + 1, y].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G + originalImage[x, y].G + originalImage[x + 1, y].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B + originalImage[x, y].B + originalImage[x + 1, y].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);
                }
                //borde der
                else if (x == width - 1)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                //borde abajo
                else if (y == 0)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);
                }
                //borde arriba
                else if (y == height - 1)
                {
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].G + originalImage[x, y + 1].G +
                                originalImage[x + 1, y + 1].G +
                                originalImage[x - 1, y].G + originalImage[x, y].G + originalImage[x + 1, y].G +
                                originalImage[x - 1, y - 1].G + originalImage[x, y - 1].G +
                                originalImage[x + 1, y + 1].G) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].B + originalImage[x, y + 1].B +
                                originalImage[x + 1, y + 1].B +
                                originalImage[x - 1, y].B + originalImage[x, y].B + originalImage[x + 1, y].B +
                                originalImage[x - 1, y - 1].B + originalImage[x, y - 1].B +
                                originalImage[x + 1, y + 1].B) / 9);

                }
                else
                {
                    //normal
                    r = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    g = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                    b = (Byte)((originalImage[x - 1, y + 1].R + originalImage[x, y + 1].R +
                                originalImage[x + 1, y + 1].R +
                                originalImage[x - 1, y].R + originalImage[x, y].R + originalImage[x + 1, y].R +
                                originalImage[x - 1, y - 1].R + originalImage[x, y - 1].R +
                                originalImage[x + 1, y + 1].R) / 9);
                }

                NewImage[x, y] = new Rgb24(r, g, b);
            }
        }
        return NewImage;
    }
}