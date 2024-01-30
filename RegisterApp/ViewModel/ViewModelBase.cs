using System.Collections.Specialized;
using System.ComponentModel;
using NLog;

namespace RegisterApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseAndSetIfChanged<T>(ref T field, T value, string propertyName)
        {
            if (field == null && value == null) return;
            if (field != null && field.Equals(value)) return;

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Logger.Debug($"Property {propertyName} changed");
        }
    }
}