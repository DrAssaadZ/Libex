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
    /// Interaction logic for saleBookLargeViewUserControl.xaml
    /// </summary>
    public partial class saleBookLargeViewUserControl : UserControl
    {
        public saleBookLargeViewUserControl()
        {           

            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string qurry = "SELECT [Book Name],Author,Cover FROM SBooks ";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(qurry, databaseConnection);
            databaseConnection.Open();
            DataTable books = new DataTable();
            adapt.Fill(books);
            databaseConnection.Close();

            string query2 = "SELECT COUNT(*) FROM SBooks";
            SqlCeCommand cmd = new SqlCeCommand(query2, databaseConnection);
            databaseConnection.Open();
            int nbrBooks = (int)cmd.ExecuteScalar();
            databaseConnection.Close();
            
            InitializeComponent();

            for (int i = 0; i < nbrBooks; i++)
            {
                SaleBookList.Items.Add(new BookModelUserControl(books.Rows[i]["Book Name"].ToString(), books.Rows[i]["Author"].ToString(), books.Rows[i]["Cover"].ToString()));
            }

            
        }
    }
}
