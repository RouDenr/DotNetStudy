using System.Windows.Controls;

namespace RegisterApp.View
{
	public partial class TabControlView : UserControl
	{
		public TabControlView()
		{
			InitializeComponent();
			DataContext = new ViewModel.TabControlViewModel();
		}
	}
}