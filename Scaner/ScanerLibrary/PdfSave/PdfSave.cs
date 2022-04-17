
using Scaner.ScanerLibrary.Interfaces;

namespace Scaner.ScanerLibrary.PdfSave;

internal class PdfSave : IScanOutputStrategy
{
    public void ScanAndSafe(IScanerDevice device, string FileName)
    {
        if (Path.GetExtension(FileName).ToLower() != ".pdf")
            throw new Exception("Не верный формат файла");

        var reader = device.Scan();

        var writer = new FileStream(FileName, FileMode.Create);
        var buffer = new byte[1024];
        int read = 0;
        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
            writer.Write(buffer, 0, read);
        }
    }
}
