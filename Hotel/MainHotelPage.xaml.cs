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
    /// Логика взаимодействия для MainHotelPage.xaml
    /// </summary>
    public partial class MainHotelPage : Page
    {
        public MainHotelPage()
        {
            InitializeComponent();
            ListViewRoom.ItemsSource = HotelEntities6.GetContext().Room.ToList();
        }

        private void BtnBron_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Bron((sender as Button).DataContext as Room));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelEntities6.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListViewRoom.ItemsSource = HotelEntities6.GetContext().Room.ToList();
            }
        }
    }
}
