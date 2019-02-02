using System.Threading.Tasks;

namespace ClientCinemaApp
{
    public interface IBarcodeScanningService
    {
        Task<string> ScanAsync();
    }
}
