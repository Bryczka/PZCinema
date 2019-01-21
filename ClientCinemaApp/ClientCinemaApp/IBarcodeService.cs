using System;
using System.IO;

namespace ClientCinemaApp
{
    public interface IBarcodeService
    {
        Stream ConvertImageStream(string text, int width = 300, int height = 130);
    }
}
