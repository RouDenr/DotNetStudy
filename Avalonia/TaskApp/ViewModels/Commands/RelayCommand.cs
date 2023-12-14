using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.Models.ApiClient;

namespace TaskApp.ViewModels.Commands;

public class RelayCommand(Action<object?> execute, Func<object?, bool> canExecute) : ICommand
{
	public event EventHandler? CanExecuteChanged;
	private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

	public bool CanExecute(object? parameter)
	{
		return canExecute(parameter);
	}
	
	public void Execute(object? parameter)
	{
		_execute(parameter);
	}
	
	public void RaiseCanExecuteChanged()
	{
		CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}