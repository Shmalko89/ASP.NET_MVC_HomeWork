using System;

namespace HW3;

internal class ViewBaseModel
{
    public SimpleCommand Command { get; set; }
    public ViewBaseModel()
    {
        this.Command = new SimpleCommand(this);
    }

    public void SimpleMethod()
    {
        Console.WriteLine("Hello");
    }
}
