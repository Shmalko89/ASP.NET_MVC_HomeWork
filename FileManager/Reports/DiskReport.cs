using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Reports;

public class DiskReport : IDiskReport
{
    public string? DiskName { get ; set ; }
    public decimal FreeSpace { get ; set; }

    public FileInfo Create(string ReportFilePath)
    {
        throw new NotImplementedException();
    }
}

