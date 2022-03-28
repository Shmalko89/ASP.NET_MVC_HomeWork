using System;
using System.Threading;
using System.Windows;

namespace Wpf_Fib
{

    public partial class MainWindow : Window
    {
        //Задание 1 и 2
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartFibNumber_ButtonClick(object sender, RoutedEventArgs e)
        {
            new Thread(
                () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        var fib_thread = Fibonachi(i);
                        FibNumber.Dispatcher.Invoke(
                            () =>
                            {
                                FibNumber.Text = fib_thread.ToString();
                            });
                    }
                }).Start();
        }
                    

        static ulong Fibonachi (int a)
        {
            if (a == 0 || a == 1)
                return 1;
            else 
                return Fibonachi(a - 2) + Fibonachi(a - 1);
        }
    }

    //Задание 3
    //fib_thread.Interrupt(); System.Threading.ThreadInterruptedException: "Поток был прерван, когда находился в состоянии ожидания."
}
