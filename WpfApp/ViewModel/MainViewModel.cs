using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApp.Model;

namespace WpfApp.ViewModel;

public class MainViewModel : ObservableObject
{
	private RelayCommand? _addPersonCommand;
	private ObservableCollection<Person> _persons;
	private string _firstName;
	private string _lastName;

	public string FirstName
	{
		get => _firstName;
		set => Set(ref _firstName, value);
	}
	
	public string LastName
	{
		get => _lastName;
		set => Set(ref _lastName, value);
	}
	
	public ObservableCollection<Person> Persons
	{
		get => _persons;
		set => Set(ref _persons, value);
	}

	public RelayCommand AddPersonCommand =>
		_addPersonCommand ??= new RelayCommand(
			() =>
			{
				var person = new Person
				{
					FirstName = FirstName,
					LastName = LastName
				};
				_persons.Add(person);
				FirstName = string.Empty;
				LastName = string.Empty;
			},
			() => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName));
}