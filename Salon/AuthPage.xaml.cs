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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        public static int userID;
        

        private void btnLabel_Click(object sender, RoutedEventArgs e)
        {
            authCheking authCheking = new authCheking();

            if (authCheking.emptyornot(loginTb.Text, passwordTb.Text) != "")
            {
                MessageBox.Show((authCheking.emptyornot(loginTb.Text, passwordTb.Text)), "We have some problems", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                Tattoo_Studio_2Entities tattoo_Studio_2Entities = new Tattoo_Studio_2Entities();

                using (var db = new Tattoo_Studio_2Entities())
                {
                    var user = db.User
                        .AsNoTracking()
                        .FirstOrDefault(u => u.Login == loginTb.Text && u.Password == passwordTb.Text);

                    if(user == null)
                    {
                        MessageBox.Show("There's no users with this datas", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    userID = user.UserId;

                    switch (user.Position)
                    {
                        case "Master2":
                            Master.MasterPage masterPage = new Master.MasterPage();
                            this.NavigationService.Navigate(masterPage);
                            break;
                        case "Admin2":
                            Admin.AdminPage adminPage = new Admin.AdminPage();
                            this.NavigationService.Navigate(adminPage);
                            break;
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Problems with authorisation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
