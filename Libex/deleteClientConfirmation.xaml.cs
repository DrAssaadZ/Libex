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

        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "DELETE FROM Clients WHERE [CLient ID] = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();

            this.Close();
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
