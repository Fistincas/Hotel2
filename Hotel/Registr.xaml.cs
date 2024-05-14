using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel
{
    public partial class Registr : Page
    {
        private guest _currentuser = new guest();
        public Registr()
        {
            InitializeComponent();
            DataContext = _currentuser;
            ComboRole.SelectedItem = HotelEntities6.GetContext().Role.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int id = random.Next(1000, 9999);
           

            string connectionString = @"Data Source=DESKTOP-15PB9VH;Initial Catalog=Hotel;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // открытие соединения с базой данных
                string username = userName.Text;
                string usersurname = userSurname.Text;
                string userlogin = txbLogin.Text;
                string userpass = userPassword.Text;
                string userrole = ComboRole.Text;

                string query = $"INSERT INTO guest (id_quest, name, surname, login, password, roleid) VALUES ('{id}', '{username}', '{usersurname}', '{userlogin}', '{userpass}', '{userrole}') ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (HotelEntities6.GetContext().guest.Count(x=> x.login == txbLogin.Text)>0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже есть");
                        return;
                    }
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации.");
                    }
                }
                connection.Close();
            }
        }
    }
}
