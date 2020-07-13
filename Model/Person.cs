using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWpfApp.Model
{
    public class Person
    {
        #region Fields
        string name;
        string position;
        DateTime birthday;
        bool isworking;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - birthday.Year;
            }
        }
        public bool IsWorking
        {
            get
            {
                return isworking;
            }
            set
            {
                isworking = value;
            }
        }
        #endregion

        public Person()
        {
            Birthday = new DateTime();
            IsWorking = false;
        }
        public Person(string _name, string _pos, DateTime _birthday, bool _isworking)
        {
            Name = _name;
            Position = _pos;
            Birthday = _birthday;
            IsWorking = _isworking;
        }
        //public void Redirection()
        //{
        //    if (isworking)
        //        isworking = false;
        //    else
        //        isworking = true;
        //}
    }
}
