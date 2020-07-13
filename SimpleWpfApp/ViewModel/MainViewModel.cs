using CommandLibrary;
using SimpleWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        Person currentPerson;
        ObservableCollection<Person> people;
        int quant;
        int freequant;

        RelayCommand _sort;
        RelayCommand _add;
        RelayCommand _edit;
        RelayCommand _rem;
        RelayCommand _getbusy;
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
        public ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
                OnPropertyChanged("People");
            }
        }
        public int EmployeesQuantity
        {
            get
            {
                return quant;
            }
            set
            {
                quant = value;
                OnPropertyChanged("EmployeesQuantity");
            }
        }
        public int FreeEmployeesQuantity
        {
            get
            {
                return freequant;
            }
            set
            {
                freequant = value;
                OnPropertyChanged("FreeEmployeesQuantity");
            }
        }
        #endregion

        #region Commands
        public ICommand SortCommand
        {
            get
            {
                return _sort ??
                    (_sort = new RelayCommand(Sort));
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return _add ??
                    (_add = new RelayCommand((x) =>
                    {
                        Person p = ViewModel.AddPerson();
                        if (p != null)
                        {
                            People.Add(p);
                            Sort("name");
                            Update();
                        }
                    }));
            }
        }
        public ICommand EditCommand
        {
            get
            {
                return _edit ??
                    (_edit = new RelayCommand((x) =>
                    {
                        Person p = ViewModel.EditPerson(CurrentPerson);
                        if (p != null)
                            CurrentPerson.Position = p.Position;
                    }, x => CurrentPerson != null));
            }
        }
        public ICommand RemCommand
        {
            get
            {
                return _rem ?? (_rem = new RelayCommand(x =>
                {
                    People.Remove(CurrentPerson);
                    Update();
                }, x => CurrentPerson != null));
            }
        }
        public ICommand GetBusyCommand
        {
            get
            {
                return _getbusy ??
                    (_getbusy = new RelayCommand((x) =>
                    {
                        Person p = CurrentPerson;
                        if (p.IsWorking)
                            p.IsWorking = false;
                        else
                            p.IsWorking = true;
                        People.Remove(CurrentPerson);
                        CurrentPerson = p;
                        People.Add(CurrentPerson);
                        Sort("name");
                        Update();
                    }, x => CurrentPerson != null));
            }
        }
        #endregion

        #region Methods
        public MainViewModel()
        {
            People = PeopleRepository.GetPeople();
            Sort("name");
            Update();
        }

        void Sort(object o)
        {
            string param = (string)o;
            switch (param)
            {
                case "name":
                    People = new ObservableCollection<Person>(People.OrderBy(x => x.Name));
                    break;
                case "age":
                    People = new ObservableCollection<Person>(People.OrderBy(x => x.Age));
                    break;
                case "pos":
                    People = new ObservableCollection<Person>(People.OrderBy(x => x.Position));
                    break;
                case "busy":
                    People = new ObservableCollection<Person>(People.OrderBy(x => x.IsWorking));
                    break;
            }
        }
        void Update()
        {
            EmployeesQuantity = People.Count;
            FreeEmployeesQuantity = People.Where(x => !x.IsWorking).Count();
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
