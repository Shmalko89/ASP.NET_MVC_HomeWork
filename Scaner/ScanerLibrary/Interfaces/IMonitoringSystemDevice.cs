

namespace Scaner.ScanerLibrary.Interfaces;

public interface IMonitoringSystemDevice
{
    IEnumerator<IData> GetEnumerator();
}
