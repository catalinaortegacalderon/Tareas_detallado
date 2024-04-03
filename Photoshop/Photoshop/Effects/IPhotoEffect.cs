using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop.Effects;

public interface IPhotoEffect
{
    string Description { get; }
    Image<Rgb24> Apply(Image<Rgb24> originalImage);
}