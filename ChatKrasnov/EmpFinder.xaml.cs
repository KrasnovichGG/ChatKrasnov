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

namespace ChatKrasnov
{
    /// <summary>
    /// Логика взаимодействия для EmpFinder.xaml
    /// </summary>
    public partial class EmpFinder : Window
    {
        public EmpFinder()
        {
            InitializeComponent();
            LstEmployee.ItemsSource = App.chatEntitiesDB.Employee.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            var search = App.chatEntitiesDB.Employee.ToList();
            search = search.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            LstEmployee.ItemsSource = search.ToList();
        }
    }
}
