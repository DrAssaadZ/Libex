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
    /// Interaction logic for rentABookUserControl.xaml
    /// </summary>
    public partial class rentABookUserControl : UserControl
    {
        #region Variables
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();   
        #endregion

        public rentABookUserControl()
        {
            InitializeComponent();
            fillBookComboBox();
            fillClientComboBox();
        }

        //confirmation button click event
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rBookComboBox.Text.Length < 2 || clientBox.Text.Length < 2 || FutureDatePicker.Text.Length < 2 || DateTime.Compare(DateTime.Parse(FutureDatePicker.Text), DateTime.Today) < 0)
            {
                if (rBookComboBox.Text.Length < 2)
                {
                    hint1.Text = "select a book";
                }
                else
                {
                    hint1.Text = "";
                }
                if (clientBox.Text.Length < 2)
                {
                    hint2.Text = "Select a clienty";
                }
                else
                {
                    hint2.Text = "";
                }
                if (FutureDatePicker.Text.Length < 2)
                {
                    hint3.Text = "Enter date";
                }
                else if (DateTime.Compare(DateTime.Parse(FutureDatePicker.Text), DateTime.Today) < 0)
                {
                    hint3.Text = "Select a future date";
                }
                else
                {
                    hint3.Text = "";
                }
            }
            else
            {
                confirmSnack.IsActive = true;
                DispatcherTimerConfirmSnack();
                Rent obj = new Rent(int.Parse(bookIDBox.Text),int.Parse(clientIDBox.Text),float.Parse(finalPriceBox.Text),"Rent",DateTime.Parse(FutureDatePicker.Text));
                obj.RentAbook();
                //printing the rent receipt
                printRentBookUserControl obj2 = new printRentBookUserControl(bookNameBox.Text,int.Parse(bookIDBox.Text),authorBox.Text,int.Parse(clientIDBox.Text),float.Parse(finalPriceBox.Text),DateTime.Today.ToString(),FutureDatePicker.Text.ToString());
                obj2.print();
            }

        }

        #region snackbar dispatcher methods
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

        #region comboBoxes methods
        //function that fills the book combo box from the Rbooks table
        public void fillBookComboBox()
        {

            string query = "SELECT [Book Name] FROM RBooks";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, databaseConnection);
            DataTable books = new DataTable();
            databaseConnection.Open();
            adapter.Fill(books);
            for (int i = 0; i < books.Rows.Count; i++)
            {
                rBookComboBox.Items.Add(books.Rows[i]["Book Name"]);
            }
            databaseConnection.Close();
        }

        //function that fills the client combo box from the clients table 
        public void fillClientComboBox()
        {
            string query = "SELECT [Client ID], Name, [Last Name] FROM Clients";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, databaseConnection);
            DataTable clients = new DataTable();
            adapter.Fill(clients);
            for (int i = 0; i < clients.Rows.Count; i++)
            {
                string fullName = clients.Rows[i]["Name"].ToString() + ". " + clients.Rows[i]["Last Name"].ToString();
                clientComboBox.Items.Add((object)fullName);

            }
        }

        // showing the client infos in the right panel 
        private void clientComboBox_DropDownClosed(object sender, EventArgs e)
        {

            if (clientComboBox.Text != "")
            {
                string query = "SELECT [Client ID],Name,[Last Name] FROM Clients WHERE [Client ID] = '" + (clientComboBox.SelectedIndex + 1).ToString() + "'";
                SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
                DataTable client = new DataTable();
                adapt.Fill(client);
                clientIDBox.Text = client.Rows[0]["Client ID"].ToString();
                clientBox.Text = client.Rows[0]["Name"].ToString() + client.Rows[0]["Last Name"].ToString();
            }


        }

        //showing the book info in the right panel
        private void rBookComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (rBookComboBox.Text != "")
            {
                string query = "SELECT [RBook ID],[Book Name],Author,[Book ISBN],Genre,Price,Audience,Cover FROM RBooks WHERE [Book Name] = '" + rBookComboBox.Text + "'";
                SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
                DataTable books = new DataTable();
                databaseConnection.Open();
                adapt.Fill(books);
                bookIDBox.Text = books.Rows[0]["RBook ID"].ToString();
                bookNameBox.Text = books.Rows[0]["Book Name"].ToString();
                authorBox.Text = books.Rows[0]["Author"].ToString();
                ISBNBox.Text = books.Rows[0]["Book ISBN"].ToString();
                genreBox.Text = books.Rows[0]["Genre"].ToString();
                priceBox.Text = books.Rows[0]["Price"].ToString();
                audienceBox.Text = books.Rows[0]["Audience"].ToString();
                bookCoverImg.Source = new BitmapImage(new Uri(books.Rows[0]["Cover"].ToString()));
                databaseConnection.Close();
            }
            finalPriceBox.Text = priceBox.Text;
        }
        #endregion

        #region calculating reduction methods
        //method that calculates the reduction value
        public void calculateReduction()
        {
            if (reductionValue.Text != "")
            {
                float reduction = (float.Parse(priceBox.Text) * float.Parse(reductionValue.Text)) / 100;
                float newValue = float.Parse(priceBox.Text) - reduction;
                finalPriceBox.Text = String.Format("{0:0.00}", newValue);
            }
            else
            {
                finalPriceBox.Text = priceBox.Text;
            }
        }

        //showin the reduction value in the final price
        private void reductionValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateReduction();
        }

        //calculating the reduction value when checkbox is checked
        private void reductionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (rBookComboBox.Text != "")
            {

                calculateReduction();
            }

        }

        //setting the final price as the price when checkbox is unchecked
        private void reductionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            finalPriceBox.Text = priceBox.Text;
        } 
        #endregion

    }
}
