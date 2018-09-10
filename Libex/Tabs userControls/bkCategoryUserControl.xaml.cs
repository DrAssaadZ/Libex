using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
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

namespace Libex
{
    /// <summary>
    /// Interaction logic for bkCategoryUserControl.xaml
    /// </summary>
    public partial class bkCategoryUserControl : UserControl
    {
        string Type = "SBooks";
        public bkCategoryUserControl()
        {
            InitializeComponent();
        }


        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Type = "RBooks";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Type = "SBooks";
        }
       
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "SELECT [Book Name], [Book ISBN],[Book Edition],[Author],[Price],[Language],[Quantity],[Book Rating] FROM " + Type + " WHERE Genre ='" + categoryComboxBox.Text + "' AND [Book Name] LIKE '%" + searchBox.Text + "%'";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            categoryBookDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }
       
        private void categoryComboxBox_DropDownClosed(object sender, EventArgs e)
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "SELECT [Book Name], [Book ISBN],[Book Edition],[Author],[Price],[Language],[Quantity],[Book Rating] FROM " + Type + " WHERE Genre ='" + categoryComboxBox.Text + "'";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            categoryBookDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }
    }
}
