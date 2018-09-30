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

namespace Libex
{
    /// <summary>
    /// Interaction logic for ReturnedBooksUserControl.xaml
    /// </summary>
    public partial class ReturnedBooksUserControl : UserControl
    {
        public ReturnedBooksUserControl()
        {
            InitializeComponent();
        }

        //books returning today button click event
        private void bkReturnTdyBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Books Returning Today",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            bkReturnTdyUserControl UC1 = new bkReturnTdyUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        //delayed books button click event
        private void delayedBkBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Delayed Books",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            delayBkUserControl UC1 = new delayBkUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
