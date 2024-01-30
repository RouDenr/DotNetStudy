using RegisterApp.ViewModel;
using System.Windows.Controls;

namespace RegisterApp.View
{
	public partial class RegistrationView : UserControl
	{
		public RegistrationView()
		{
			InitializeComponent();
			DataContext = new RegistrationViewModel();
		}
	}
}