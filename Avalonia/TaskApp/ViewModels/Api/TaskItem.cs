using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace TaskApp.ViewModels.Api;

public sealed class TaskItem : INotifyPropertyChanged
{
	
	[JsonConstructor]
	public TaskItem(int id, string title, string description, bool isComplete)
	{
		Id = id;
		Title = title;
		Description = description;
		IsComplete = isComplete;
	}
	
	public TaskItem(Request.ResponseTaskItem responseTaskItem)
	{
		Id = responseTaskItem.id;
		Title = responseTaskItem.title;
		Description = responseTaskItem.description;
		IsComplete = responseTaskItem.isDone;
	}

	#region Properties
	private int _id;
	private string _title = "";
	private string _description = "";
	private bool _isComplete;
	[JsonPropertyName("id")]
	public int Id
	{
		get => _id;
		set => Set(ref _id, value);
	}
	[JsonPropertyName("title")]
	public string Title
	{
		get => _title;
		set => Set(ref _title, value);
	}
	[JsonPropertyName("description")]
	public string Description
	{
		get => _description;
		set => Set(ref _description, value);
	}
	[JsonPropertyName("isDone")]
	public bool IsComplete
	{
		get => _isComplete;
		set => Set(ref _isComplete, value);
	}
	#endregion
	
	// OnPropertyChanged is a method that is called when a property is changed.
	public event PropertyChangedEventHandler? PropertyChanged;
	
	private void Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return;
		field = value;
		OnPropertyChanged(propertyName);
	}

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}