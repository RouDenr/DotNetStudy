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
            
        }

        protected virtual void OnLoginEvent()
        {
            LoginEvent?.Invoke();
        }
    }
}
