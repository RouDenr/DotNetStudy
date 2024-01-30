using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using RegisterApp.View;
using RegisterApp.ViewModel;

namespace RegisterApp.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private readonly List<UserControl> _views = new List<UserControl>
		{
			new TabControlView(),
			new WelcomeView()
		};
		
		private UserControl _currentView;

		public UserControl CurrentView
		{
			get => _currentView;
			set => RaiseAndSetIfChanged(ref _currentView, value, nameof(CurrentView));
		}
		
		public MainViewModel()
		{
			CurrentView = _views[0];

			// Find LoginViewModel in TabControlView and subscribe to LoginEvent
			if (!(CurrentView is TabControlView tabControlView)) return;
			
			TabControlViewModel tabControlViewModel = tabControlView.DataContext as TabControlViewModel;
			
			if (!(tabControlViewModel?.LoginView.DataContext is LoginViewModel loginViewModel)) return;
				
			loginViewModel.LoginEvent += NextView;
		}
		
		
		/// <summary>
		/// Change view to next view in list
		/// </summary>
		public void NextView()
		{
			var currentIndex = _views.IndexOf(CurrentView);

			CurrentView = currentIndex == _views.Count - 1 ?
				_views[0] : _views[currentIndex + 1];
		}
	}
}