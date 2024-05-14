using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }
        public int username;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = HotelEntities6.GetContext().guest.FirstOrDefault(p => p.login == userLogin.Text && p.password == userPassword.Text);
                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
                else
                {
                    switch (currentUser.roleid)
                    {
                        case "Admin": Manager.MainFrame.Navigate(new AdminEmploee());
                            break;

                        case "User":
                            Manager.MainFrame.Navigate(new MainHotelPage());
                            break;

                        case "Emploee":
                            Manager.MainFrame.Navigate(new AdminEmploee());
                            break;
                    }
                    DataBank.Userid = currentUser.id_quest;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ошибка " + ex.Message.ToString() + "Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registr());
        }
    }
}
