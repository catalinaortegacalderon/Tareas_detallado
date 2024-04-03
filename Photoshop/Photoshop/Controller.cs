using Photoshop.Effects;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Photoshop;

public static class Controller
{
    private static List<string> _imagePaths;
    private static string _fullPath;
    private static IPhotoEffect[] _availableEffects;
    private static Image<Rgb24> _originalImage;
    private static IPhotoEffect _effect;
    private static Image<Rgb24> _resultingImage;
    
    public static void Run(string folder, IPhotoEffect[] availableEffects)
    {
        Console.WriteLine("¡Bienvenido!");
        _availableEffects = availableEffects;
        _fullPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), folder);
        CreateFolderIfItDoesntExist(folder);
        _imagePaths = GetImageFiles(folder);
        if (_imagePaths.Any())
            AskUserToApplyEffectToAnImage();
        else
            TellUserToAddImagesToFolder();
        Console.WriteLine("\nQue tengas un buen día :)");
    }
    
    private static void CreateFolderIfItDoesntExist(string folder)
    {
        if (!Directory.Exists(folder)) 
            Directory.CreateDirectory(folder);
    }

    private static List<string> GetImageFiles(string folder)
    {
        List<string> imagePaths = new List<string>();
        foreach (string file in Directory.GetFiles(folder))
            if (file.EndsWith(".jpg") || file.EndsWith(".png"))
                imagePaths.Add(file);

        return imagePaths;
    }

    private static void AskUserToApplyEffectToAnImage()
    {
        AskForImage();
        AskForEffect();
        ApplyEffect();
        SaveResultingImage();
        Clean();
    }

    private static void AskForImage()
    {
        ShowImagePaths();
        int imageId = AskForNumber(0, _imagePaths.Count - 1);
        string imagePath = _imagePaths[imageId];
        _originalImage = Image.Load<Rgb24>(imagePath);
    }

    private static void ShowImagePaths()
    {
        Console.WriteLine("En este minuto existen las siguientes imágenes en tu directorio:\n" + _fullPath + "\n");
        for (int i = 0; i < _imagePaths.Count; i++)
            Console.WriteLine(i + "- " + _imagePaths[i]);
    }
    
    private static int AskForNumber(int minValue, int maxValue)
    {
        Console.WriteLine("Ingresa una opción válida: ");
        int number;
        bool wasParseSuccessfull;
        do
        {
            string? userInput = Console.ReadLine();
            wasParseSuccessfull = int.TryParse(userInput, out number);
        } while (!wasParseSuccessfull || number < minValue || number > maxValue);

        return number;
    }

    private static void AskForEffect()
    {
        ShowEffects();
        int idEffect = AskForNumber(0, _availableEffects.Length - 1);
        _effect = _availableEffects[idEffect];
    }

    private static void ShowEffects()
    {
        Console.WriteLine("\n¿Qué efecto deseas usar en la imagen?");
        for (int i = 0; i < _availableEffects.Length; i++)
            Console.WriteLine(i + "- " + _availableEffects[i].Description);
    }

    private static void ApplyEffect()
    {
        Console.Write("\nAplicando el efecto... ");
        _resultingImage = _effect.Apply(_originalImage);
        Console.Write("listo!");
    }
    
    private static void SaveResultingImage()
    {
        Console.WriteLine("\n¿Con qué nombre quieres guardar la imagen?");
        string fileName = Console.ReadLine();
        string savePath = Path.Combine(_fullPath, $"{fileName}.png");
        _resultingImage.Save(savePath);
        Console.WriteLine("¡Listo! Tu imagen fue guardada.");
    }
    
    private static void Clean()
    {
        _originalImage.Dispose();
        _resultingImage.Dispose();
    }
    
    private static void TellUserToAddImagesToFolder()
    {
        Console.WriteLine("\nEn este minuto no existe ninguna imagen en:\n" + _fullPath);
        Console.WriteLine("Por favor agrega alguna imagen .jpg o .png a la carpeta.");
    }
}