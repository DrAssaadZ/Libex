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
    /// Interaction logic for clientListUserControl.xaml
    /// </summary>
    public partial class clientListUserControl : UserControl
    {
        
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public clientListUserControl()
        {
            InitializeComponent();
            ShowClientsDataGrid();
        }

        public void ShowClientsDataGrid()
        {            
            
            string query = "SELECT * FROM Clients";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query,databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            clientListDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();

        }

        //refresh button click
        private void refreshClientList_Click(object sender, RoutedEventArgs e)
        {
            ShowClientsDataGrid();
        }

        private void printIDBtn_Click(object sender, RoutedEventArgs e)
        {
                       
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            deleteClientConfirmation obj = new deleteClientConfirmation();
            obj.ShowDialog();

            //update dataGrid after deletion            
            ShowClientsDataGrid();
        }
    }
}
