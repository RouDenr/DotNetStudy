using System.Windows;
using System.Windows.Controls;

namespace RegisterApp.Components
{
	public partial class BindablePasswordBox : UserControl
	{
		public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty));


		public string Password
		{
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

		public BindablePasswordBox()
		{
			InitializeComponent();
		}
	}
}