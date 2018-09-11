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
    /// Interaction logic for currRentBooksUserControl.xaml
    /// </summary>
    public partial class currRentBooksUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public currRentBooksUserControl()
        {
            InitializeComponent();
            fillCurrentRentBDataGrid();
        }

        //function that fills the currently rent books data grid 
        public void fillCurrentRentBDataGrid()
        {
            string query = "SELECT * FROM Rents";
            SqlCeCommand cmd = new SqlCeCommand(query,databaseConnection);
            databaseConnection.Open();
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable books = new DataTable();
            adapt.Fill(books);
            currRentBookDataGrid.ItemsSource = books.DefaultView;
            databaseConnection.Close();
        }
    }
}
