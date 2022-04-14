using Scaner.ScanerLibrary.Interfaces;

namespace Scaner.ScanerLibrary.Scaner;

internal class ScanerDevice : IScanerDevice
{
    private string _path;

    public ScanerDevice(string path)
    {
        _path = path;
    }
    public Stream Scan()
    {
        var memorystream = new MemoryStream();
        var stream = new StreamReader(_path);
        var line = stream.ReadLine();
        while (line != null)
        {
            Console.WriteLine(line);
            line = stream.ReadLine();
            Console.WriteLine();
        }
        return memorystream;
    }

}
