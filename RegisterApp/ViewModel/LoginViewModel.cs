using System.Windows.Input;
using RegisterApp.ViewModel;

namespace RegisterApp.ViewModel
{
    public class LoginViewModel : UserInputViewModel
    {
        public event Action LoginEvent;
        public ICommand LoginCommand { get; }
        
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LoginUser);
        }

        private void LoginUser(object obj)
        {
            InputEnabled = false;
            try
            {
                Model.LoginUser.Login(Login, Password);
                OnLoginEvent();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

            InputEnabled = true;
        }


        protected virtual void OnLoginEvent()
        {
            LoginEvent?.Invoke();
        }
    }
}
