using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace TaskApp.ViewModels;

public class ViewModelBase : ReactiveObject
{
	protected void Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return;
		field = value;
		this.RaisePropertyChanged(propertyName);
	}
}