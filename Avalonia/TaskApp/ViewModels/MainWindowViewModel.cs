using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Styling;
using ReactiveUI;
using TaskApp.Models;
using TaskApp.Models.ApiClient;
using TaskApp.ViewModels.Commands;

namespace TaskApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	
	private ObservableCollection<TaskItem>? _tasks = new();
	private TaskItem _selectedTask;
	
	private string _searchText = "";
	private string _searchResults = "";
	
	
	public ObservableCollection<TaskItem>? Tasks
	{
		get => _tasks;
		set => Set(ref _tasks, value);
		
	}
	public TaskItem SelectedTask
	{
		get => _selectedTask;
		set => Set(ref _selectedTask, value);
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
		UpdateTaskCommand = new RelayCommand(LoadTasks, (o => true));
		RemoveTaskCommand = new RelayCommand(RemoveTask, (o => true));
	}

	private void RemoveTask(object? obj)
	{
		if (obj is not TaskItem task) return;
		
		RemoveTask(task);
	}

	private void LoadTasks(object? obj)
	{
		LoadTasks();
	}

	private async void RemoveTask(TaskItem task)
	{
		await Request.DeleteTask(task.Id);
		LoadTasks();
	}
	
	private async void LoadTasks()
	{
		ObservableCollection<TaskItem>? loadedTasks = await Request.GetTasks();

		if (loadedTasks != null)
		{
			Tasks = new ObservableCollection<TaskItem>(loadedTasks);
		}
		else
		{
			// Handle the case where loading tasks failed
			Console.WriteLine("Failed to load tasks from the API.");
		}
	}
#pragma warning disable CA1822 // Mark members as static
	public ICommand UpdateTaskCommand { get; }
	public ICommand RemoveTaskCommand { get; }
#pragma warning restore CA1822 // Mark members as static
}