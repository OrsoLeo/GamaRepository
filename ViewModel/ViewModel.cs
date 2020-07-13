using SimpleWpfApp.Model;
using SimpleWpfApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWpfApp.ViewModel
{
    //Класс осуществляет взаимодействие между ViewModels окон приложения, напрямую они не контактируют
    class ViewModel
    {
        public static Person CurrentPerson { get; set; }      

        
        public static Person AddPerson()
        {
            AddWindow aw = new AddWindow();
            aw.ShowDialog();
            return CurrentPerson;
        }

        public static Person EditPerson(Person p)
        {
            EditWindow ew = new EditWindow(p);
            ew.ShowDialog();
            return CurrentPerson;
        }
    }
}
