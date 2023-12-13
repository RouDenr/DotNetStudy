using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Styling;
using ReactiveUI;

namespace TaskApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	
	private ObservableCollection<TaskItem> _tasks = new();
	private string _searchText = "";
	private string _searchResults = "";
	
	
	public ObservableCollection<TaskItem> Tasks
	{
		get => _tasks;
		set => Set(ref _tasks, value);
		
	}
	public string SearchText
	{
		get => _searchText;
		set => Set(ref _searchText, value);
	}

	public string SearchResults
	{
		get => _searchResults;
		set => Set(ref _searchResults, value);
	}

	private string _newTaskText = "";
	public string NewTaskText
	{
		get => _newTaskText;
		set => Set(ref _newTaskText, value);
	}

	public MainWindowViewModel()
	{
		Tasks =
		[
			new TaskItem
			{
				Id = 1,
				Title = "Task 1",
				Description = "Description 1",
				IsComplete = false
			},

			new TaskItem
			{
				Id = 2,
				Title = "Task 2",
				Description = "Description 2",
				IsComplete = false
			},

			new TaskItem
			{
				Id = 3,
				Title = "Task 3",
				Description = "Description 3",
				IsComplete = false
			}
		];
	}
	
#pragma warning disable CA1822 // Mark members as static
	public string Greeting => "Welcome to Avalonia!";
	public ICommand AddTaskCommand { get; } = new AddCommand();
	public ICommand RemoveTaskCommand { get; } = new RemoveCommand();
#pragma warning restore CA1822 // Mark members as static
}