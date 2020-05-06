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
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace Salon.Master
{
    /// <summary>
    /// Логика взаимодействия для masterWorks.xaml
    /// </summary>
    public partial class masterWorks : Page
    {
        Tattoo_Studio_2Entities context = new Tattoo_Studio_2Entities();
        public static int workID;

        public void updateDatagrid()
        {
            /// Fill a datagrid
            var query = (from portfolio in context.Portfolio
                         where portfolio.MasterId == AuthPage.userID
                         select new
                         {
                             Name = portfolio.Name,
                             Image = portfolio.Image
                         }).ToList();
            worksDataGrid.ItemsSource = query;
        }
        

        public masterWorks()
        {
            InitializeComponent();

            updateDatagrid();
        }

        /// Go to add window
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addMasterWork addMasterWork = new addMasterWork();
            addMasterWork.Show();
        }
        
        /// Get ID of the work and go to edit window
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var query = (from portfolio in context.Portfolio
                             where portfolio.MasterId == AuthPage.userID
                             select new
                             {
                                 id = portfolio.WorkId,
                                 Name = portfolio.Name,
                                 Image = portfolio.Image
                             }).ToList();
                workID = query[worksDataGrid.SelectedIndex].id;

                editMasterWork editMasterWork = new editMasterWork();
                editMasterWork.Show();
            }
            catch
            {
                MessageBox.Show("Choose a work you want to change", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

        }

        /// Delete 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                var query = (from portfolio in context.Portfolio
                             where portfolio.MasterId == AuthPage.userID
                             select new
                             {
                                 id = portfolio.WorkId,
                                 Name = portfolio.Name,
                                 Image = portfolio.Image
                             }).ToList();
                workID = query[worksDataGrid.SelectedIndex].id;
                if (MessageBox.Show("Do you really want to delete this work?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Portfolio work = context.Portfolio
                        .Where(w => w.WorkId == workID)
                        .FirstOrDefault();
                    context.Portfolio.Remove(work);
                    context.SaveChanges();
                }
                updateDatagrid();
            }
            catch
            {
                MessageBox.Show("Choose a work you want to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            

        }
    }
}
