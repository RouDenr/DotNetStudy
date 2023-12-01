using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace WpfApp.ViewModel;

public class ViewModelLocator
{
	static ViewModelLocator()
	{
		ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
		SimpleIoc.Default.Register<MainViewModel>();
	}
	
	public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
}