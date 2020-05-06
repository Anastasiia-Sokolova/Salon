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

namespace Salon.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void workersBtn_Click(object sender, RoutedEventArgs e)
        {
            adminWorkers adminWorkers = new adminWorkers();
            this.NavigationService.Navigate(adminWorkers);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adminSchedule adminSchedule = new adminSchedule();
            this.NavigationService.Navigate(adminSchedule);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            personalNumber personalNumber = new personalNumber();
            this.NavigationService.Navigate(personalNumber);
        }
    }
}
