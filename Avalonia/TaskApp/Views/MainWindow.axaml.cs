using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TaskApp.ViewModels;

namespace TaskApp.Views;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}
}