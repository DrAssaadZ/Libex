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
    /// Interaction logic for sellABookUserControl.xaml
    /// </summary>
    public partial class sellABookUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        public sellABookUserControl()
        {
            InitializeComponent();
            fillBookComboBox();
        }

        //confirm button click event
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sBookComboBox.Text.Length < 2 || agePeriod.Text.Length < 2)
            {
                if (sBookComboBox.Text.Length < 2)
                {
                    hint1.Text = "Select a Book";
                }
                else
                {
                    hint1.Text = "";
                }
                if (agePeriod.Text.Length < 2)
                {
                    hint2.Text = "Select age period";
                }
                else
                {
                    hint2.Text = "";
                }
            }
            else
            {
                confirmSnack.IsActive = true;
                DispatcherTimerConfirmSnack();
                Sell obj = new Sell(bookNameBox.Text,ISBNBox.Text,genreBox.Text,float.Parse(finalPriceBox.Text),agePeriod.Text);
                obj.SellABook();
                //printing the receipt
                printSoldBookUserControl obj2 = new printSoldBookUserControl(bookNameBox.Text,authorBox.Text,genreBox.Text,float.Parse(finalPriceBox.Text));
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

        #region combobox methods
        //method that fill the books combo box from the sale books
        public void fillBookComboBox()
        {

            string query = "SELECT [Book Name] FROM SBooks";
            SqlCeDataAdapter cmd = new SqlCeDataAdapter(query, databaseConnection);
            DataTable books = new DataTable();
            databaseConnection.Open();
            cmd.Fill(books);
            for (int i = 0; i < books.Rows.Count; i++)
            {
                sBookComboBox.Items.Add(books.Rows[i]["Book Name"]);
            }
            databaseConnection.Close();
        }

        //showing selected book information in the right panel
        private void sBookComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sBookComboBox.Text != "")
            {
                string query = "SELECT [Book Name],Author,[Book ISBN],Genre,Price,Audience, Cover FROM SBooks WHERE [Book Name] ='" + sBookComboBox.Text + "'";
                SqlCeDataAdapter cmd = new SqlCeDataAdapter(query, databaseConnection);
                DataTable book = new DataTable();
                databaseConnection.Open();
                cmd.Fill(book);
                bookNameBox.Text = book.Rows[0]["Book Name"].ToString();
                authorBox.Text = book.Rows[0]["Author"].ToString();
                ISBNBox.Text = book.Rows[0]["Book ISBN"].ToString();
                genreBox.Text = book.Rows[0]["Genre"].ToString();
                priceBox.Text = book.Rows[0]["Price"].ToString();
                audienceBox.Text = book.Rows[0]["Audience"].ToString();
                bookCoverImg.Source = new BitmapImage(new Uri(book.Rows[0]["Cover"].ToString()));
                databaseConnection.Close();
            }
            finalPriceBox.Text = priceBox.Text;
        } 
        #endregion

        #region reduction value methods
        //reduction box is checked
        private void reductionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sBookComboBox.Text != "")
            {

                calculateReduction();
            }

        }

        //calculating the final price based on the reduction value 
        private void reductionValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateReduction();
        }

        //restoring the previous price if unchecking the reduction check box
        private void reductionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            finalPriceBox.Text = priceBox.Text;
        }

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
        #endregion
    }

}
