using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Styling;
using ReactiveUI;
using TaskApp.ViewModels.Api;
using TaskApp.ViewModels.Commands;

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
			new TaskItem(1, "Task 1", "Description 1", false),
			new TaskItem(2, "Task 2", "Description 2", false),
			new TaskItem(3, "Task 3", "Description 3", false),
		];
	}
	
#pragma warning disable CA1822 // Mark members as static
	public string Greeting => "Welcome to Avalonia!";
	public ICommand AddTaskCommand { get; } = new AddCommand();
	public ICommand RemoveTaskCommand { get; } = new RemoveCommand();
#pragma warning restore CA1822 // Mark members as static
}