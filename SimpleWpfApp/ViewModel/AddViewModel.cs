using CommandLibrary;
using SimpleWpfApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModel
{
    class AddViewModel : INotifyPropertyChanged
    {
        #region Fields
        Person currentPerson;
        Window window;
        RelayCommand _save;
        #endregion

        #region Properties
        public Person CurrentPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value;
                OnPropertyChanged("CurrentPerson");
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                return _save ?? (_save = new RelayCommand((x) =>
                {
                    window.Close();
                    ViewModel.CurrentPerson = CurrentPerson;
                }));
            }
        }
        #endregion

        #region Methods
        public AddViewModel(Window w)
        {
            window = w;
            CurrentPerson = new Person();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {       
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
