using System;
using System.Collections.ObjectModel;

namespace SimpleWpfApp.Model
{
    class PeopleRepository
    {
        public static ObservableCollection<Person> GetPeople()
        {
            return new ObservableCollection<Person>
            {
                new Person("Leda", "Junior Developer", new DateTime(1991, 06, 11), true),
                new Person("Nolan", "Junior Developer", new DateTime(1997, 09, 22), false),
                new Person("Kate", "Manager", new DateTime(1990, 05, 21), true),
                new Person("Peter", "Junior Developer", new DateTime(1993, 11, 17), true),
                new Person("Leo", "Junior Developer", new DateTime(1991, 06, 12), false),
                new Person("Mark", "Middle Developer", new DateTime(1990, 02, 13), true),
                new Person("Tom", "Leader", new DateTime(1988, 03, 15), true),
                new Person("Sergio", "Administrator", new DateTime(1986, 10, 02), false)
            };
        }
    }
}
