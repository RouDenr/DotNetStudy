using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.Models;
using TaskApp.Models.ApiClient;
using TaskApp.ViewModels.Commands;

namespace TaskApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
	
	private ObservableCollection<TaskItem>? _tasks = new();
	private TaskItem? _selectedTask;
	
	private string _searchText = "";
	
	public ObservableCollection<TaskItem>? Tasks
	{
		get => _tasks;
		set => Set(ref _tasks, value);
		
	}
	public TaskItem? SelectedTask
	{
		get => _selectedTask;
		set => Set(ref _selectedTask, value);
	}

	public string SearchText
	{
		get => _searchText;
		set => Set(ref _searchText, value);
	}
	private string _newTaskTitle = "";
	public string NewTaskTitle
	{
		get => _newTaskTitle;
		set => Set(ref _newTaskTitle, value);
	}
	
	private string _newTaskDescription = "";

	public string NewTaskDescription
	{
		get => _newTaskDescription; 
		set => Set(ref _newTaskDescription, value);
	}

	public MainWindowViewModel()
	{
		SelectedTask = null;
		AddTaskCommand = new RelayCommand(CreateTask, (_ => true));
		UpdateTaskCommand = new RelayCommand(LoadTasks, (_ => true));
		RemoveTaskCommand = new RelayCommand(RemoveTask, (_ => true));
		SwitchTaskCommand = new RelayCommand(SwitchTask, (_ => true));
		SearchCommand = new RelayCommand(SearchTask, (_ => true));
		LoadTasks();
	}

	private async void SearchTask(object? obj)
	{
		await LoadTasks();
		if (SearchText == "") return;

		Console.WriteLine($"Searching for {SearchText}");
		if (Tasks != null)
			Tasks = new ObservableCollection<TaskItem>(Tasks.Where(task => task.Title.Contains(SearchText)));
	}

	private void SwitchTask(object? obj)
	{
		if (obj is not TaskItem task) return;
		
		task.IsDone = !task.IsDone;
		UpdateTask(task.Id, task);
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
	
	private void CreateTask(object? obj)
	{
		CreateTask();
	}

	private async void UpdateTask(int id, TaskItem task)
	{
		if (task.Id != id) return;
		
		await Request.PutTask(id, task);
		Console.WriteLine($"Updated task with id {id}");
		await LoadTasks();
	}
	
	private async void CreateTask()
	{
		TaskItem newTask = new(0, NewTaskTitle, NewTaskDescription, false);
		await Request.PostTask(newTask);
		await LoadTasks();
	}
	
	private async void RemoveTask(TaskItem task)
	{
		await Request.DeleteTask(task.Id);
		await LoadTasks();
	}
	
	private async Task LoadTasks()
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
	public ICommand AddTaskCommand { get; }
	public ICommand SwitchTaskCommand { get; }
	public ICommand SearchCommand { get; }
#pragma warning restore CA1822 // Mark members as static
}