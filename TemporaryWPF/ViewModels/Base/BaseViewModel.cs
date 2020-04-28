using System;
using System.ComponentModel;


namespace TemporaryWPF
{
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

            public void OnPropertyChanged(string name)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
}
