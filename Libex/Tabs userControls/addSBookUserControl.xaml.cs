using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Libex.Tabs_userControls
{
    /// <summary>
    /// Interaction logic for addSBookUserControl.xaml
    /// </summary>
    public partial class addSBookUserControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();        
        public addSBookUserControl()
        {
            InitializeComponent();
        }
  
        //add button click event
        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bookNameBox.Text.Length < 1 || ISBNBox.Text.Length < 1 || quantityBox.Text.Length < 1 || editionYearBox.Text.Length < 4 || authorBox.Text.Length < 2 || nbrPagesBox.Text.Length < 1)
            {
                if (bookNameBox.Text.Length < 1)
                {
                    hint1.Text = "Name is empty or too short";
                }
                else
                {
                    hint1.Text = "";
                }
                if (authorBox.Text.Length < 2)
                {
                    hint2.Text = "Author is empty or too short";
                }
                else
                {
                    hint2.Text = "";
                }
                if (ISBNBox.Text.Length < 1)
                {
                    hint3.Text = "ISBN is empty or too short";
                }
                else if (!int.TryParse(ISBNBox.Text, out int x))
                {
                    hint3.Text = "ISBN should be a number";
                }
                else if (nbrPagesBox.Text.Length < 1)
                {
                    hint3.Text = "Enter number of pages";
                }
                else if (!int.TryParse(nbrPagesBox.Text, out int x2))
                {
                    hint3.Text = "NUMBER of pages should be a NUMBER";
                }
                else
                {
                    hint3.Text = "";
                }
                if (editionYearBox.Text.Length < 1)
                {
                    hint4.Text = "Year of edition  is empty or too short";
                }
                else if (!int.TryParse(ISBNBox.Text, out int x))
                {
                    hint4.Text = "year should be a number";
                }
                else
                {
                    hint4.Text = "";
                }
                if (priceBox.Text.Length < 1)
                {
                    hint5.Text = "price is empty or too short";
                }
                else if (!float.TryParse(ISBNBox.Text, out float x))
                {
                    hint5.Text = "price should be a number";
                }
                else if (quantityBox.Text.Length < 1)
                {
                    hint5.Text = "Enter quantity";
                }
                else if (!float.TryParse(quantityBox.Text, out float x2))
                {
                    hint5.Text = "quantity should be a NUMBER";
                }
                else if (float.Parse(quantityBox.Text) <= 1)
                {
                    hint5.Text = "quantity should be >= 1";
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

                SBook obj = new SBook(bookNameBox.Text, ISBNBox.Text, int.Parse(editionYearBox.Text), int.Parse(nbrPagesBox.Text), authorBox.Text, audienceBox.Text, copyrightHolderBox.Text, editorBox.Text
                                        , genreBox.Text, float.Parse(priceBox.Text), languagebox.Text, illustratorBox.Text, int.Parse(quantityBox.Text), BasicRatingBar.Value, coverContainer.Source, aboutBox.Text);
                obj.insertSaleBook();
            }
            //confirmSnack.IsActive = true;
            //DispatcherTimerConfirmSnack();
           
            //SBook obj = new SBook(bookNameBox.Text, ISBNBox.Text,int.Parse(editionYearBox.Text),int.Parse(nbrPagesBox.Text),authorBox.Text,audienceBox.Text,copyrightHolderBox.Text,editorBox.Text
            //                        ,genreBox.Text, float.Parse( priceBox.Text),languagebox.Text,illustratorBox.Text,int.Parse(quantityBox.Text),BasicRatingBar.Value,coverContainer.Source,aboutBox.Text);
            //obj.insertSaleBook();           
        }

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

        //cover button click event
        private void coverBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select image";
                dialog.Filter = "Image files (*.png;*.jpeg,*.jpg)|*.png;*.jpeg;*.jpg";
                if (dialog.ShowDialog() == true)
                {
                    //image source                                      
                    coverContainer.Source = new BitmapImage(new Uri(dialog.FileName));                   
                }
            }
            catch (Exception)
            {               
                MessageBox.Show("Please pick an image file");
            }
        }

    }
}
