using System;

namespace ProxyPattern
{
    public interface IImage
    {
        void Display();
    }
    public class RealImage : IImage
    {
        private string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading image: {_fileName}");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image: {_fileName}");
        }
    }
    public class ProxyImage : IImage
    {
        private string _fileName;
        private RealImage _realImage;

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            
            if (_realImage == null)
            {
                _realImage = new RealImage(_fileName);
            }
            _realImage.Display();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            IImage image1 = new ProxyImage("photo1.jpg");
            IImage image2 = new ProxyImage("photo2.jpg");

            
            Console.WriteLine("First time accessing image1:");
            image1.Display();

            
            Console.WriteLine("\nAccessing image1 again:");
            image1.Display();

            Console.WriteLine("\nAccessing image2:");
            image2.Display();
        }
    }
}