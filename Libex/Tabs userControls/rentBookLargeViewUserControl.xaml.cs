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
    /// Interaction logic for rentBookLargeViewUserControl.xaml
    /// </summary>
    public partial class rentBookLargeViewUserControl : UserControl
    {
        public rentBookLargeViewUserControl()
        {
            //querying the books in the Sale books database 
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string qurry = "SELECT [Book Name],[Book ISBN],[Book Edition],Editor,Genre,Price,Author,About,Cover FROM RBooks ";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(qurry, databaseConnection);
            databaseConnection.Open();
            DataTable books = new DataTable();
            adapt.Fill(books);
            databaseConnection.Close();

            //querying number of books in the sale books database
            string query2 = "SELECT COUNT(*) FROM RBooks";
            SqlCeCommand cmd = new SqlCeCommand(query2, databaseConnection);
            databaseConnection.Open();
            int nbrBooks = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            InitializeComponent();

            //showing the books in the books list 
            for (int i = 0; i < nbrBooks; i++)
            {
                rentBookList.Items.Add(new BookModelUserControl(books.Rows[i]["Book Name"].ToString(), books.Rows[i]["Author"].ToString(), books.Rows[i]["Cover"].ToString()
                                        , books.Rows[i]["Book ISBN"].ToString(), int.Parse(books.Rows[i]["Book Edition"].ToString()), books.Rows[i]["Editor"].ToString(), books.Rows[i]["Genre"].ToString(), float.Parse(books.Rows[i]["Price"].ToString()), books.Rows[i]["About"].ToString()));
            }

        }
    }
}
