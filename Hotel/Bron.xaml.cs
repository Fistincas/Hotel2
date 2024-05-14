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
    /// <summary>
    /// Логика взаимодействия для Bron.xaml
    /// </summary>
    public partial class Bron : Page
    {
        public Room _currenbron = new Room();
        private Reservation _currentreserv = new Reservation();
        public Bron(Room reservation)
        {
            InitializeComponent();
            if (reservation != null)
            {
                _currenbron = reservation;
            }
            DataContext = _currenbron;
            

        }


        private void Bronirov_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-15PB9VH;Initial Catalog=Hotel;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Random random = new Random();
                int id = random.Next(1000, 9999);
                connection.Open();
                int Room = Convert.ToInt32(idroom.Text);
                int user = Convert.ToInt32(iduser.Text);
                string checkin = txbcheckIn.Text;
                string departure = txbdeparture.Text;
                string bookingstatus = "Забронировано";

                string query = $"INSERT INTO Reservation (id_reserv, checkin, departure, bookingStatus, id_user, roomNumber) VALUES ('{id}', '{checkin}', '{departure}', '{bookingstatus}', '{user}', '{Room}') ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //if (HotelEntities6.GetContext().Reservation.Count(x => x.id_user == Convert.ToInt32(iduser.Text)) > 0)
                    //{
                    //    MessageBox.Show("вы уже забронировали комнату");
                    //    return;
                    //}
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            iduser.Text = Convert.ToString(DataBank.Userid);
        }
    }
}
