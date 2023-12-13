using System;
using System.Windows.Input;

namespace TaskApp.ViewModels;

public class RemoveCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public bool CanExecute(object? parameter)
	{
		return true;
	}

	public void Execute(object? parameter)
	{
		Console.WriteLine("RemoveCommand");
	}
}