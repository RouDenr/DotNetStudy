using System;
using System.Windows.Input;
using RegisterApp.Model;

namespace RegisterApp.ViewModel
{
	public class RegistrationViewModel : ViewModelBase
	{
        
		private string _login = string.Empty;
		private string _password = string.Empty;
        
		public string Login { get => _login; set => RaiseAndSetIfChanged(ref _login, value, nameof(Login)); }
		public string Password { get => _password; set => RaiseAndSetIfChanged(ref _password, value, nameof(Password)); }

		public ICommand RegistrationCommand { get; }

		public RegistrationViewModel()
		{
			RegistrationCommand = new RelayCommand(RegistrationUser);
        }

        private void RegistrationUser(object obj)
        {
	        try
	        {
		        Registration.Register(Login, Password);
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }
        }
    }
}