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

namespace Salon.Master
{
    /// <summary>
    /// Логика взаимодействия для masterSchedule.xaml
    /// </summary>
    public partial class masterSchedule : Page
    {
        public masterSchedule()
        {
            InitializeComponent();

            Tattoo_Studio_2Entities context = new Tattoo_Studio_2Entities();

            var query = from schedule in context.Schedule
                        where schedule.MasterId == AuthPage.userID
                        join client in context.Client on schedule.ClientId equals client.ClientId
                        select new
                        {
                            Client = client.Name,
                            Phone = client.Phone,
                            Time = schedule.Date_and_time
                        };
            scheduleDataGrid.ItemsSource = query.ToList();
        }
    }
}
