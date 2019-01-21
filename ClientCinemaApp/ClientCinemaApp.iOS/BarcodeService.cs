using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ClientCinemaApp.iOS.BarcodeService))]
namespace ClientCinemaApp.iOS
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
                    Margin = 10
                }
            };
            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            var bitmap = barcodeWriter.Write(text);
            var stream = bitmap.AsPNG().AsStream(); // this is the difference 
            stream.Position = 0;

            return stream;
        }
    }
}