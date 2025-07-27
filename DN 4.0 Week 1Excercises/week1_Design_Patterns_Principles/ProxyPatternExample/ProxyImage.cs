using System;

// IImage.cs
public interface IImage
{
    void Display();
}

// RealImage.cs
public class RealImage : IImage
{
    private readonly string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading {_filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying {_filename}");
    }
}

// ProxyImage.cs
public class ProxyImage : IImage
{
    private RealImage _realImage;
    private readonly string _filename;

    public ProxyImage(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_filename);
        }
        _realImage.Display();
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        IImage image = new ProxyImage("test_image.jpg");

        // Image will be loaded from disk
        image.Display();

        // Image will not be loaded from disk
        image.Display();
    }
}
