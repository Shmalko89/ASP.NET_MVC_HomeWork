using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1;

public static class ThreadLimit
{
    public static void Run()
    {
        ThreadPool.SetMaxThreads(10, 10);

        Process[] currentProcess = Process.GetProcesses();

        foreach (var proc in currentProcess)
        {
            ThreadPool.QueueUserWorkItem(parameter =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Process: {0}", proc);
            });
        }
        Console.ReadLine();
    }
}
