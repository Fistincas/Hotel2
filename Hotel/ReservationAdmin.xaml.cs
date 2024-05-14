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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для ReservationAdmin.xaml
    /// </summary>
    public partial class ReservationAdmin : Page
    {
        public ReservationAdmin()
        {
            InitializeComponent();
            DGreservation.ItemsSource = HotelEntities6.GetContext().Reservation.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
