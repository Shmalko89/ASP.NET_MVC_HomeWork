using Scaner.ScanerLibrary.Interfaces;

namespace Scaner.ScanerLibrary.Data;

public struct Data : IData
{
    public int CpuMetric { get; }

    public int MemoryMetric { get; }
}
