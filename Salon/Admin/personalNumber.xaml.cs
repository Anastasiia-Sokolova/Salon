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
using TattooAppLib;

namespace Salon.Admin
{
    /// <summary>
    /// Логика взаимодействия для personalNumber.xaml
    /// </summary>
    public partial class personalNumber : Page
    {
        public personalNumber()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (surnametb.Text == "" || birthyeartb.Text == "")
            {
                return;
            }

            string surname = surnametb.Text;
            int year = Convert.ToInt32(birthyeartb.Text);

            authCheking authCheking = new authCheking();
            resulttb.Text = authCheking.createPersonalNumber(surname, year);

        }
    }
}
