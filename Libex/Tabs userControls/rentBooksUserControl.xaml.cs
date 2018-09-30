using Libex.Tabs_userControls;
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
    /// Interaction logic for rentBooksUserControl.xaml
    /// </summary>
    public partial class rentBooksUserControl : UserControl
    {
        rentBookGridViewUserControl gridView = new rentBookGridViewUserControl();
        
        public rentBooksUserControl()
        {
            InitializeComponent();
        }


        #region toggle button methods
        //showing the grid view of the books when the tab is created as default view
        private void rentBookUserControlMainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(gridView);
        }
        //grid view  toggle button checked event
        private void saleBookViewBtn_Checked(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(new rentBookLargeViewUserControl());
        }

        //large view toggle button unchecked event
        private void saleBookViewBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(gridView);
        } 
        #endregion

        //rent a book button click event
        private void rentBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Rent a book",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            addRBookUserControl UC1 = new addRBookUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
        //search
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "SELECT [RBook ID], [Book Name], [Book ISBN],[Book Edition],[Author],[Genre],[Price],[Language],[BookRating] FROM RBooks WHERE [Book Name] LIKE '%" + searchBar.Text + "%'" ;
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            gridView.rentBookDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }
    }
}
