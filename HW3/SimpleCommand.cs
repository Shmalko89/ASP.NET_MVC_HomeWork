using System;
using System.Windows.Input;

namespace HW3;

internal class SimpleCommand :ICommand
{
    public ViewBaseModel ViewBaseModel { get; set; }
    public SimpleCommand(ViewBaseModel viewBaseModel)
    {
        this.ViewBaseModel = viewBaseModel;
    }
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        this.ViewBaseModel.SimpleMethod();
    }
}
