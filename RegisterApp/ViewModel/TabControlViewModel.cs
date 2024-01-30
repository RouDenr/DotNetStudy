using System.Collections.Generic;
using System.Windows.Controls;
using RegisterApp.View;

namespace RegisterApp.ViewModel
{
	public class TabControlViewModel : ViewModelBase
	{
		private UserControl _loginView = new LoginView();
		private UserControl _registrationView = new RegistrationView();
		
		public UserControl LoginView
		{
			get => _loginView;
			set => RaiseAndSetIfChanged(ref _loginView, value, nameof(LoginView));
		}
		public UserControl RegistrationView
		{
			get => _registrationView;
			set => RaiseAndSetIfChanged(ref _registrationView, value, nameof(RegistrationView));
		}
		
	}
}