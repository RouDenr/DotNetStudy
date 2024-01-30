using System;
using System.Windows.Input;
using RegisterApp.Model;

namespace RegisterApp.ViewModel
{
	public class RegistrationViewModel : UserInputViewModel
	{
		public ICommand RegistrationCommand { get; }

		public RegistrationViewModel()
		{
			RegistrationCommand = new RelayCommand(RegistrationUser);
		}

        private void RegistrationUser(object obj)
        {
	        InputEnabled = false;
	        try
	        {
		        Registration.Register(Login, Password);
	        }
	        catch (UserAlreadyExistsException)
	        {
		        ErrorMessage = "User already exists";
	        }
	        catch (Exception e)
	        {
		        ErrorMessage = e.Message;
	        }

	        InputEnabled = true;
        }
    }
}