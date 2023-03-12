using ChatKrasnov.DB;
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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        List<Employee> existEmployees;
        int idChatRoom = 0;
        public AddUser(List<Employee> lst, int idChatRoom)
        {
            InitializeComponent();
            this.idChatRoom = idChatRoom;
            existEmployees = lst;

            List<Employee> employees = App.chatEntitiesDB.Employee.ToList();
            List<Employee> resEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                bool state = true;
                foreach (var item in existEmployees)
                {
                    if (employee.Id == item.Id)
                        state = false;
                }
                if (state)
                    resEmployees.Add(employee);
            }

            CmbboxUser.ItemsSource = resEmployees;
        }
        private void BtnADD_Click(object sender, RoutedEventArgs e)
        {
            if (CmbboxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите юзера!");
            }
            var selectEmployee = (Employee)CmbboxUser.SelectedItem;
            Employee_ChatRoom addItem = new Employee_ChatRoom();
            addItem.Id_ChatRoom = idChatRoom;
            addItem.Employee = selectEmployee;
            App.chatEntitiesDB.Employee_ChatRoom.Add(addItem);
            App.chatEntitiesDB.SaveChanges();
            MessageBox.Show("Успешно!");
        }
    }
}
