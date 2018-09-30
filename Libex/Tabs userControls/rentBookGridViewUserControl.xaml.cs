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

namespace Libex.Tabs_userControls
{
    /// <summary>
    /// Interaction logic for rentBookGridViewUserControl.xaml
    /// </summary>
    public partial class rentBookGridViewUserControl : UserControl
    {
        public rentBookGridViewUserControl()
        {
            InitializeComponent();
            ShowRBooksDataGrid();
        }

        //showing the rent books in the data grid
        public void ShowRBooksDataGrid()
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "SELECT [RBook ID], [Book Name], [Book ISBN],[Book Edition],[Author],[Genre],[Price],[Language],[BookRating] FROM RBooks";
            databaseConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            rentBookDataGrid.ItemsSource = data.DefaultView;
            databaseConnection.Close();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowRBooksDataGrid();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            deleteRBookConfirmation obj = new deleteRBookConfirmation();
            obj.ShowDialog();

            //update dataGrid after deletion            
            ShowRBooksDataGrid();
        }
        
    }
}
