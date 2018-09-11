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
    /// Interaction logic for soldBooksUserControl.xaml
    /// </summary>
    public partial class soldBooksUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public soldBooksUserControl()
        {
            InitializeComponent();
            fillSoldBooksBDataGrid();
        }

        //method that fill the sold books data grid 
        public void fillSoldBooksBDataGrid()
        {
            string query = "SELECT * FROM Sells";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(cmd);
            DataTable books = new DataTable();
            adapt.Fill(books);
            soldBooksDataGrid.ItemsSource = books.DefaultView;
            databaseConnection.Close();
        }

    }
}
