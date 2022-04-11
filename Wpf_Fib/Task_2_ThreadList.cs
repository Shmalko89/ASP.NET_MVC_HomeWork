using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wpf_Fib
{
    internal class Task_2_ThreadList
    {
        public static void Run()
        {
            var list = new List<string>();
            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var thread_id = Environment.CurrentManagedThreadId;
                    for (var j = 0; j < 100; j++)
                    {
                        lock (list)
                            list.Add($"{thread_id}");
                        Thread.Sleep(1000);
                    }
                });
            }
        }
    }
}
