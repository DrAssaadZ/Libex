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

        public void ShowOrdersDataGrid()
        {

            string query = "SELECT [Client ID],[Book Name],Author,Language,Price FROM commands";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            ordersDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowOrdersDataGrid();
        }
    }
}
