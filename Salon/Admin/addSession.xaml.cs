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

namespace Salon.Admin
{
    /// <summary>
    /// Логика взаимодействия для addSession.xaml
    /// </summary>
    public partial class addSession : Window
    {
        Tattoo_Studio_2Entities context = new Tattoo_Studio_2Entities();
        public addSession()
        {
            InitializeComponent();
           

            var query = from user in context.User
                        where user.Position == "Master"
                        select new
                        {
                            Name = user.Name,
                            ID = user.UserId
                        };
            masterCB.ItemsSource = query.ToList();
            masterCB.DisplayMemberPath = "Name";
            masterCB.SelectedValuePath = "ID";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            Client client = new Client
            {
                Name = nameTb.Text,
                Surname = surnameTb.Text,
                Phone = phoneTb.Text
            };
            context.Client.Add(client);
            context.SaveChanges();

           


            Schedule schedule = new Schedule
            {
                MasterId = Convert.ToInt32(masterCB.SelectedValue),
                ClientId = client.ClientId,
                Date_and_time = Convert.ToDateTime(dataPicker.SelectedDate)
            };
            context.Schedule.Add(schedule);
            context.SaveChanges();
        }
    }
}
