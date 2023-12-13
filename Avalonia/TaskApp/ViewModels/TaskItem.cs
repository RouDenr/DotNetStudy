using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskApp.ViewModels;

public sealed class TaskItem : INotifyPropertyChanged
{

	#region Properties
	private int _id;
	private string _title = "";
	private string _description = "";
	private bool _isComplete;
	public int Id
	{
		get => _id;
		set => Set(ref _id, value);
	}
	public string Title
	{
		get => _title;
		set => Set(ref _title, value);
	}
	public string Description
	{
		get => _description;
		set => Set(ref _description, value);
	}
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