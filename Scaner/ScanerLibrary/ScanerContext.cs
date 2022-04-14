using Scaner.ScanerLibrary.Interfaces;

namespace Scaner.ScanerLibrary;

public class ScanerContext
{
    private readonly IScanerDevice? _device;
    private readonly ILogger? _logger;
    private readonly IScanOutputStrategy? _outputStrategy;
    private ScanerContext(IScanerDevice device, ILogger logger, IScanOutputStrategy outputStrategy)
    {
        _device = device;
        _logger = logger;
        _outputStrategy = outputStrategy;
    }

    public void Execute(string outputFileName = "")
    {
        if (_device == null)
        {
            throw new ArgumentNullException("Устройство не найдено");
        }
        if (_outputStrategy == null)
        {
            throw new ArgumentNullException("Операция не удалась");
        }
        if (string.IsNullOrEmpty(outputFileName))
        {
            outputFileName = Guid.NewGuid().ToString();
        }
        _outputStrategy.ScanAndSafe(_device, outputFileName);
    }


}
