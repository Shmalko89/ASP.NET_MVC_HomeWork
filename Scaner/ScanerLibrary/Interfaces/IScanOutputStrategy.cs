

namespace Scaner.ScanerLibrary.Interfaces;

public interface IScanOutputStrategy
{
    void ScanAndSafe (IScanerDevice device, string FileName);
}
