using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW2;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private CancellationTokenSource _cancellationTokenSource;
    private async void StartCalculation_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (sender is not Button start_button) return;
        start_button.IsEnabled = false;
        CancelButton.IsEnabled = true;

        IProgress<double> progress = new Progress<double>(p => ProgressInformer.Value = p * 100);

        var cancellation_source = new CancellationTokenSource();
        _cancellationTokenSource = cancellation_source;

        try
        {
            ResultTextBlock.Text = await ProcessCalculatingAsync(50, progress, cancellation_source.Token);
        }
        catch (OperationCanceledException)
        {
            progress.Report(0);
            ResultTextBlock.Text = "Операция отменена";
        }
        CancelButton.IsEnabled = false;
        start_button.IsEnabled = true;
    }

    private void CancelCalculation_ButtonClick(object sender, RoutedEventArgs e)
    {
        _cancellationTokenSource?.Cancel();
    }

    private static async Task<string> ProcessCalculatingAsync (int Timeout = 100, IProgress<double>? progress = null, CancellationToken cancel = default)
    {
        cancel.ThrowIfCancellationRequested();
        const int progress_count = 100;
        if(Timeout > 0)
            for(int i = 0; i < 100; i++)
            {
                if (cancel.IsCancellationRequested)
                {
                    cancel.ThrowIfCancellationRequested();
                }
                await Task.Delay(Timeout).ConfigureAwait(false);
                progress?.Report((double)i / progress_count);
            }

        progress?.Report(1);
        cancel.ThrowIfCancellationRequested();
        return DateTime.Now.ToString();
    }
}
