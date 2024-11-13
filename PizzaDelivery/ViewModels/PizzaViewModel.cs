using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PizzaDelivery.ViewModels
{
    public enum PizzaSizes
    {
        Small,
        Medium,
        Large
    }
    public class PizzaViewModel : ViewModelBase
    {
        private readonly PizzaDto _dto;
        public string Name => _dto.C_name;

        public string Description => _dto.description;

        public byte[]? Image => _dto.pizzaimage;

        public PizzaViewModel(PizzaDto dto)
        {
            _dto = dto;
        }

        public static BitmapImage ByteToImage(byte[] blob)
        {
            

            if (blob == null || blob.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(blob))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
