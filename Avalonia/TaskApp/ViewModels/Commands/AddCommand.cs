using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.ViewModels.Api;

namespace TaskApp.ViewModels.Commands;

public class AddCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public bool CanExecute(object? parameter)
	{
		return true;
	}
	
	public async void Execute(object? parameter)
	{
		var list = await Request.GetTasks();

		if (list != null)
		{
			foreach (var taskItem in list)
			{
				Console.WriteLine(taskItem.Title);
			}
		}
	}
}