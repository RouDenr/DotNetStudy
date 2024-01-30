using System.Collections.Specialized;
using System.ComponentModel;

namespace RegisterApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseAndSetIfChanged<T>(ref T field, T value, string propertyName)
        {
            RaiseAndSetIfChanged(ref field, value, PropertyChanged, propertyName);
        }

        private static void RaiseAndSetIfChanged<T>(ref T field, T value, PropertyChangedEventHandler handler, string propertyName)
        {
            if (propertyName == null)
                throw new System.ArgumentNullException(nameof(propertyName));

            if (Equals(field, value)) return;
            
            field = value;
            handler?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}