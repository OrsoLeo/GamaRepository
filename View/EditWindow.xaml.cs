using SimpleWpfApp.Model;
using SimpleWpfApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleWpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        EditViewModel data;
        public EditWindow()
        {
            InitializeComponent();
        }
        public EditWindow(Person p)
        {
            InitializeComponent();
            data = new EditViewModel(this, p);
            DataContext = data;
        }
    }
}
