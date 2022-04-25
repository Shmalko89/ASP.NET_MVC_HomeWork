using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Reports;
public interface IDiskReport
{
    string DiskName { get; set; }
    decimal FreeSpace { get; set; }

    FileInfo Create(string ReportFilePath);
}

