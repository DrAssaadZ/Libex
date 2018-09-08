using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Libex.Tabs_userControls
{
    /// <summary>
    /// Interaction logic for addRBookUserControl.xaml
    /// </summary>
    public partial class addRBookUserControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        public addRBookUserControl()
        {
            InitializeComponent();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmSnack.IsActive = true;
            DispatcherTimerConfirmSnack();

            RBook obj = new RBook(bookNameBox.Text, ISBNBox.Text, int.Parse(editionYearBox.Text), int.Parse(nbrPagesBox.Text), bookAuthorBox.Text, AudienceBox.Text, copyrightHolderBox.Text, editorBox.Text
                                    , genreBox.Text, float.Parse(priceBox.Text), languageBox.Text, illustratorBox.Text, BasicRatingBar.Value, coverContainer.Source, aboutBox.Text);
            obj.insertRentBook();
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

        //add cover button click event
        private void AddCoverBtn_Click(object sender, RoutedEventArgs e)
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
