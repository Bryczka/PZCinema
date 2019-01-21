using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientCinemaApp
{
    public interface IBarcodeScanningService
    {
        Task<string> ScanAsync();
    }
}
