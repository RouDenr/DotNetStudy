using RegisterApp.ViewModel;

namespace RegisterApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public event Action LoginEvent;
        
        private string _login = string.Empty;
        private string _password = string.Empty;
        
        public string Login { get => _login; set => RaiseAndSetIfChanged(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => RaiseAndSetIfChanged(ref _password, value, nameof(Password)); }
        
        
        public LoginViewModel()
        {
            
        }

        protected virtual void OnLoginEvent()
        {
            LoginEvent?.Invoke();
        }
    }
}
