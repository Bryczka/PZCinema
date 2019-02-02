using Android.Graphics;
using System.IO;


[assembly: Xamarin.Forms.Dependency(typeof(ClientCinemaApp.Droid.BarcodeService))]
namespace ClientCinemaApp.Droid
{
    public class BarcodeService : IBarcodeService
    {
        public Stream ConvertImageStream(string text, int width = 300, int height = 300)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 3

                }
            };

            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            var bitmap = barcodeWriter.Write(text);
            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Position = 0;
            return stream;
        }
    }
}