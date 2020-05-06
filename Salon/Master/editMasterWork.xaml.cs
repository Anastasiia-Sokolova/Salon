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
using System.Data.SqlClient;

namespace Salon.Master
{
    /// <summary>
    /// Логика взаимодействия для editMasterWork.xaml
    /// </summary>
    public partial class editMasterWork : Window
    {
        public editMasterWork()
        {
            InitializeComponent();

            //Product product = context.Product.Find(Products.productID);
            //nametb.Text = product.Name;
            //quantitytb.Text = product.Quantity.ToString();
            //quantityunittb.Text = product.Quantity_unit;
            //costtb.Text = product.Cost.ToString();
            //cb1.SelectedValue = product.DiscountID;
            //cb2.SelectedValue = product.ManufacturerID;
            //descriptiontb.Text = product.Description;

            Tattoo_Studio_2Entities context = new Tattoo_Studio_2Entities();

            Portfolio portfolio = context.Portfolio.Find(masterWorks.workID);
            nameTb.Text = portfolio.Name;
        }

        private void changePhotoBtn_Click(object sender, RoutedEventArgs e)
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

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string ConnectionString = @"Data Source=DESKTOP-F4BU4E2\ANASTASIASQL;Initial Catalog=Tattoo_Studio_2;User id=sa; Password=golegyr10";
                string sqlQuery = @"UPDATE Portfolio set [Name] = '"+ nameTb.Text +"', [Image] = (Select BulkColumn FROM Openrowset(Bulk '"+ pathTb.Text +"', Single_Blob) as EmployeePicture) where WorkId = " + masterWorks.workID;
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        int number = command.ExecuteNonQuery();
                        MessageBox.Show("Изменено объектов: " + number);
                        this.Hide();
                    }
            }
            catch
            {
                MessageBox.Show("Some problems", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
