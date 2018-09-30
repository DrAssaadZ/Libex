using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlServerCe;

namespace Libex
{
    /// <summary>
    /// Interaction logic for deleteClientConfirmation.xaml
    /// </summary>
    public partial class deleteClientConfirmation : Window
    {
        public deleteClientConfirmation()
        {
            InitializeComponent();
        }

        //yes button click event
        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "SELECT COUNT (*) FROM Rents WHERE [Client ID] = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int numberOfRents = (int) cmd.ExecuteScalar();
            databaseConnection.Close();

            //deleting the client if he is not currently renting a book
            if (numberOfRents == 0)
            {
                query = "DELETE FROM Clients WHERE [CLient ID] = '" + GlobalVariables.dataRowView[0] + "'";
                SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
                databaseConnection.Open();
                cmd2.ExecuteNonQuery();
                databaseConnection.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("Client is currently renting a book");
                this.Close();
            }
        }

        //no button click event
        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
