namespace RegisterApp.ViewModel;

public class UserInputViewModel : ViewModelBase
{
	private string _login = string.Empty;
	private string _password = string.Empty;
	private string _errorMessage = string.Empty;
	private bool _inputEnabled = true;


	public string Login { get => _login; set => RaiseAndSetIfChanged(ref _login, value, nameof(Login)); }
	public string Password { get => _password; set => RaiseAndSetIfChanged(ref _password, value, nameof(Password)); }
	public string ErrorMessage { get => _errorMessage; set => RaiseAndSetIfChanged(ref _errorMessage, value, nameof(ErrorMessage)); }
	public bool InputEnabled { get => _inputEnabled; set => RaiseAndSetIfChanged(ref _inputEnabled, value, nameof(InputEnabled)); }
}