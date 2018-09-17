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

        //showing the client in the client data grid 
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

        //print button on the client list clicked event
        private void printIDBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;            
            //query to get the client info on the selected row
            string query = "SELECT [Client ID], Name, [Last Name],Gender FROM Clients WHERE [Client ID] = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(query,databaseConnection);
            DataTable data = new DataTable();
            adapt.Fill(data);
           //instanciating an object from the print user control for the client info selected 
            printClientUserControl obj = new printClientUserControl(int.Parse(data.Rows[0]["Client ID"].ToString()), data.Rows[0]["Name"].ToString(), data.Rows[0]["Last Name"].ToString(), data.Rows[0]["Gender"].ToString());
            obj.print();
        }

        // delete button on the client list clicked event
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            deleteClientConfirmation obj = new deleteClientConfirmation();
            obj.ShowDialog();

            //update dataGrid after deletion            
            ShowClientsDataGrid();
        }

        //search bar method
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = "SELECT * FROM Clients WHERE Name Like '%" + searchBar.Text + "%' OR [Last Name] LIKE'%" + searchBar.Text + "%'";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            clientListDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }

        
    }
}
