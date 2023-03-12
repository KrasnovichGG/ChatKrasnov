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
    /// Логика взаимодействия для WinChat.xaml
    /// </summary>
    public partial class WinChat : Window
    {
        public Employee_ChatRoom chat;
        List<Employee> lst;
        public WinChat(Employee_ChatRoom employee_Chat)
        {
            InitializeComponent();

            chat = employee_Chat;
            lst = new List<Employee>();
            foreach (var chatrooms in App.chatEntitiesDB.Employee_ChatRoom.Where(x => x.Id_ChatRoom == employee_Chat.Id_ChatRoom))
            {
                lst.Add(App.chatEntitiesDB.Employee.Where(x => x.Id == chatrooms.Id_Employee).FirstOrDefault());
            }
            lstemployee.ItemsSource = lst;
            tbChatName.Text = employee_Chat.ChatRoom.Topic;
        }

        private void BtnChToop_Click(object sender, RoutedEventArgs e)
        {
            UserWin userWin = new UserWin();
            userWin.Show();
            Close();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(lst,chat.Id_ChatRoom);
            addUser.Show();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            ChatMessage message = new ChatMessage();
            {
                tbMessage.Text = message.Message;
            }
        }

       
    }
}
