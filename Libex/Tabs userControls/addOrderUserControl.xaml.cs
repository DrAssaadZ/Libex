using Libex.Project_Classes;
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
    /// Interaction logic for addOrderUserControl.xaml
    /// </summary>
    public partial class addOrderUserControl : UserControl
    {
        #region variables
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer(); 
        #endregion
        public addOrderUserControl()
        {
            InitializeComponent();
            fillClientComboBox();
        }

        //add order button click event
        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientIDBox.Text.Length < 1 || BooksNameComboBox.Text.Length < 1  || bookAuthorBox.Text.Length < 1 || bookEditionBox.Text.Length < 1 || bookPrice.Text.Length < 1 || !int.TryParse(bookEditionBox.Text,out int x) || !float.TryParse(bookPrice.Text, out float x2))
            {
                //client id user entry control
                if (ClientIDBox.Text.Length < 1)
                {
                    hint1.Text = "Please select a client ID";
                }
                else
                {
                    hint1.Text = "";
                }
                //book name user entry control
                if (BooksNameComboBox.Text.Length < 4)
                {
                    hint2.Text = "Book name too short or empty ";
                }
                else
                {
                    hint2.Text = "";
                }
                //author user entry control
                if (bookAuthorBox.Text.Length < 2)
                {
                    hint3.Text = "Author name too short or empty";
                }
                else
                {
                    hint3.Text = "";
                }
                //book edition user entry control
                if (bookEditionBox.Text.Length < 4)
                {
                    hint4.Text = "Please pick a correct year";
                }
                else if (!int.TryParse(bookEditionBox.Text, out int x3))
                {
                    hint4.Text = "Edition year must be a number";
                }
                else
                {
                    hint4.Text = "";
                }
                //price user entry control
                if (!int.TryParse(bookPrice.Text, out int x4))
                {
                    hint6.Text = "The price must be a number";
                }
                else
                {
                    hint6.Text = "";
                }
            }
            else
            {
                // no hint needed when insertion is successful
                hint1.Text = "";
                hint2.Text = "";
                hint3.Text = "";
                hint4.Text = "";
                hint5.Text = "";
                hint6.Text = "";
                //confirmation message
                confirmSnack.IsActive = true;
            DispatcherTimerConfirmSnack();
                //inserting in the command database 
            Command obj = new Command(int.Parse(ClientIDBox.Text),BooksNameComboBox.Text,int.Parse( bookEditionBox.Text),bookLanguage.Text,bookAuthorBox.Text,float.Parse(bookPrice.Text));
            obj.addAnOrder();
            }

        }

        //method that fills the client combo box from the clients database
        public void fillClientComboBox()
        {
            string query = "SELECT [Client ID] FROM Clients";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
            DataTable clients = new DataTable();
            databaseConnection.Open();
            adapt.Fill(clients);
            for (int i = 0; i < clients.Rows.Count; i++)
            {
                ClientIDBox.Items.Add(clients.Rows[i]["Client ID"]);
            }
            databaseConnection.Close();
        }

        #region snackbardispatcher methods
        private void DispatcherTimerConfirmSnack()
        {
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            confirmSnack.IsActive = false;
            dispatcher.Stop();
        } 
        #endregion
    }
}
