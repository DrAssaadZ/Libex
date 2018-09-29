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
    /// Interaction logic for bkReturnTdyUserControl.xaml
    /// </summary>
    public partial class bkReturnTdyUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public bkReturnTdyUserControl()
        {
            InitializeComponent();
            fillReturnBooks();
        }

        //method that fills the return books today data grid 
        public void fillReturnBooks()
        {
            string query = "SELECT * FROM Rents WHERE [Return Day] = '" + DateTime.Today + "'";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
            databaseConnection.Open();
            DataTable booksR = new DataTable();
            adapt.Fill(booksR);
            ReturnBooksDataGrid.ItemsSource = booksR.DefaultView;
            databaseConnection.Close();
        }
    }
}
