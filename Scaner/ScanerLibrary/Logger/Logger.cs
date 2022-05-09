using Scaner.ScanerLibrary.Interfaces;

namespace Scaner.ScanerLibrary;

internal class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
