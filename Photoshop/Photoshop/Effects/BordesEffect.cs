using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public class Bordes:IPhotoEffect
{
    private readonly string _description = "Bordes de la imagen.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> NewImage = new Image<Rgb24>(width, height);
        // voy a hacer una imagen con el borde 0
        // la nueva imagen se basará en la vieja
        
        // haciendo la nueva imagen
        Image<Rgb24> ImagenAuxiliar = new Image<Rgb24>(width +2 , height +2);
        for (int x1 = 0; x1 < (width + 2); x1++)
        {
            for (int y1 = 0; y1 < (height + 2); y1++)
            {
                if (y1 == 0 || x1 == 0 || x1 == width + 1 || y1 == width + 1)
                {
                    ImagenAuxiliar[x1, y1] = new Rgb24(0, 0, 0);
                }
                else
                {
                    ImagenAuxiliar[x1, y1] = new Rgb24(originalImage[x1 - 1, y1 - 1].R,
                        originalImage[x1 - 1, y1 - 1].G,
                        originalImage[x1 - 1, y1 - 1].B);
                }
            }
        }
        // haciendo el efecto
            
        for (int x2 = 0; x2 < width; x2++)
        {
            for (int y2 = 0; y2 < height; y2++)
            {
                Byte r;
                Byte g;
                Byte b;
                //normal
                int x = x2 + 1;
                int y = y2 + 1;
                //int r = originalImage[x, y].R;
                //int g = originalImage[x, y].G;
                //int b = originalImage[x, y].B;
                //Byte averageColor = (Byte)((r+g+b) / 3);
                //hacer min y max
                int rint;
                int gint;
                int bint;
                rint = ( (8 * ImagenAuxiliar[x, y].R) - (ImagenAuxiliar[x - 1, y + 1].R + ImagenAuxiliar[x, y + 1].R +
                                                            ImagenAuxiliar[x + 1, y + 1].R +
                                                            ImagenAuxiliar[x - 1, y].R  + ImagenAuxiliar[x + 1, y].R +
                                                            ImagenAuxiliar[x - 1, y - 1].R + ImagenAuxiliar[x, y - 1].R +
                                                            ImagenAuxiliar[x + 1, y + 1].R));
                gint = ((8 * ImagenAuxiliar[x, y].G) - (ImagenAuxiliar[x - 1, y + 1].G + ImagenAuxiliar[x, y + 1].G +
                                                           ImagenAuxiliar[x + 1, y + 1].G +
                                                           ImagenAuxiliar[x - 1, y].G  + ImagenAuxiliar[x + 1, y].G +
                                                           ImagenAuxiliar[x - 1, y - 1].G + ImagenAuxiliar[x, y - 1].G +
                                                           ImagenAuxiliar[x + 1, y + 1].G));
                bint = ((8 * ImagenAuxiliar[x, y].B) -(ImagenAuxiliar[x - 1, y + 1].B + ImagenAuxiliar[x, y + 1].B +
                                                          ImagenAuxiliar[x + 1, y + 1].B +
                                                          ImagenAuxiliar[x - 1, y].B + ImagenAuxiliar[x + 1, y].B +
                                                          ImagenAuxiliar[x - 1, y - 1].B + ImagenAuxiliar[x, y - 1].B +
                                                          ImagenAuxiliar[x + 1, y + 1].B));
                // otra manera de hacerlo: poner max y min
                if (rint < 0)
                {
                    rint = 0;
                }
                if (rint > 255)
                {
                    rint = 255;
                }
                if (gint < 0)
                {
                    gint = 0;
                }
                if (gint > 255)
                {
                    gint = 255;
                }
                if (bint < 0)
                {
                    bint = 0;
                }
                if (bint > 255)
                {
                    bint = 255;
                }
                r = (Byte)(rint);
                g = (Byte)(gint);
                b = (Byte)(bint);
                NewImage[x2, y2] = new Rgb24(r, g, b);
            }
        }
        return NewImage;
    }
} 