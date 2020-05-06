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
    /// Логика взаимодействия для adminSchedule.xaml
    /// </summary>
    public partial class adminSchedule : Page
    {
        public adminSchedule()
        {
            InitializeComponent();

            Tattoo_Studio_2Entities context = new Tattoo_Studio_2Entities();

            var query = from schedule in context.Schedule
                        join client in context.Client on schedule.ClientId equals client.ClientId
                        join user in context.User on schedule.MasterId equals user.UserId
                        select new
                        {
                            Master = user.Name,
                            Client = client.Name,
                            Phone = client.Phone,
                            Time = schedule.Date_and_time
                        };
            scheduleDataGrid.ItemsSource = query.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addSession addSession = new addSession();
            addSession.Show();
        }
    }
}
