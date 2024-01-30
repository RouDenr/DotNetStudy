using System;
using System.Windows.Input;

namespace RegisterApp.ViewModel
{
	public class RegistrationViewModel
	{
		public ICommand RegistrationCommand { get; }

		public RegistrationViewModel()
		{
            RegistrationCommand = new RelayCommand(Registration);
        }

        private void Registration(object obj)
        {

        }
    }
}