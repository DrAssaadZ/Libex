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
using Libex.Tabs_userControls;

namespace Libex
{
    /// <summary>
    /// Interaction logic for listOrdersUserControl.xaml
    /// </summary>
    public partial class listOrdersUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public listOrdersUserControl()
        {
            InitializeComponent();
            ShowOrdersDataGrid();

        }

        //add order button click
        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Add an Order",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            addOrderUserControl UC1 = new addOrderUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        #region fill and refresh data grid methods
        //fill order data grid
        public void ShowOrdersDataGrid()
        {

            string query = "SELECT [cmID],[Client ID],[Book Name],Author,Language,Price FROM commands";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            ordersDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();

        }

        //refresh button click event
        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowOrdersDataGrid();
        } 
        #endregion

        //search button method 
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = "SELECT [cmID],[Client ID],[Book Name],Author,Language,Price FROM commands WHERE [Client ID] LIKE '%" + searchBar.Text + "%' OR [Book Name] LIKE '%" + searchBar.Text + "%'";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            ordersDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }


        #region grid buttons methods
        //delete button click event
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string query = "DELETE FROM commands where [cmid] = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();
            //refreshing the order data grid
            ShowOrdersDataGrid();

        }

        //print button click event
        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            //query to get the order info on the selected row
            string query = "SELECT cmID,[Book Name],[Client ID],Price FROM commands WHERE cmID ='" + GlobalVariables.dataRowView[0] + "'";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
            databaseConnection.Open();
            DataTable orders = new DataTable();
            adapt.Fill(orders);
            //instanciating an object from the print user control for the order  selected
            printOrderUserControl obj = new printOrderUserControl(int.Parse(orders.Rows[0]["cmID"].ToString()), int.Parse(orders.Rows[0]["Client ID"].ToString()), orders.Rows[0]["Book Name"].ToString(), float.Parse(orders.Rows[0]["Price"].ToString()));
            obj.print();
        }

        //sell order button click event
        private void SellOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            ////validating the command , moving it into the sells database
            string query = "INSERT INTO Sells([Book Name],[Book ISBN],Genre,Price,[Sell Date],[Client Age])Values(@bookName,@isbn,@genre,@price,@sellDate,@clientAge)";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@bookName", GlobalVariables.dataRowView[2]);
            cmd.Parameters.AddWithValue("@isbn", "0000");
            cmd.Parameters.AddWithValue("@genre", "Unspecified");
            cmd.Parameters.AddWithValue("@price", GlobalVariables.dataRowView[5]);
            cmd.Parameters.AddWithValue("@sellDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@clientAge", "Undefined");
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();

            //deleting the command after validating it 
            query = "DELETE FROM commands WHERE cmID = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            cmd2.ExecuteNonQuery();
            databaseConnection.Close();

            //refreshing the grid after deleting
            ShowOrdersDataGrid();
        } 
        #endregion
    }
}
