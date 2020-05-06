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
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;


namespace Salon.Master
{
    /// <summary>
    /// Логика взаимодействия для addMasterWork.xaml
    /// </summary>
    public partial class addMasterWork : Window
    {
        public addMasterWork()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                    pathTb.Text = dialog.FileName;
            }
            catch
            {
                MessageBox.Show("Some problems", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                string ConnectionString = @"Data Source=DESKTOP-F4BU4E2\ANASTASIASQL;Initial Catalog=Tattoo_Studio_2;User id=sa; Password=golegyr10";
                string sqlQuery = @"INSERT INTO Portfolio(MasterId, [Name], [Image]) SELECT " + AuthPage.userID + ", '" + nameTb.Text + "', BulkColumn FROM Openrowset(Bulk '" + pathTb.Text + "', Single_Blob) as EmployeePicture";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show("Добавлено объектов: " + number);
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Connection problems", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
    }
}
