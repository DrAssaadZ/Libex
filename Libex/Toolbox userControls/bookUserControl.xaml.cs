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
    /// Interaction logic for bookUserControl.xaml
    /// </summary>
    public partial class bookUserControl : UserControl
    {
        public bookUserControl()
        {
            InitializeComponent();
        }

        //books for sale button click event 
        private void forSaleBtn_Click(object sender, RoutedEventArgs e)
        {
            //creating a new tab item with the sale books user control as its content
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "For Sale Books",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            saleBooksUserControl UC1 = new saleBooksUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
        //books for rent button click event 
        private void forRentBtn_Click(object sender, RoutedEventArgs e)
        {
            //creating a new tab item with the rent books user control as its content
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "For Rent Books",
                
            };
            
            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            
            rentBooksUserControl UC1 = new rentBooksUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        //currently rent books button click event
        private void currentlyRentBtn_Click(object sender, RoutedEventArgs e)
        {
            //creating a new tab item with currently rent books user control as its content
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Currently Rent Books",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;           
            tabGrid.Children.Clear();
            currRentBooksUserControl UC1 = new currRentBooksUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        //sold books button click event
        private void soldBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            //creating a new tab item with soldbooksusercontrol as its content
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Sold Books",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            soldBooksUserControl UC1 = new soldBooksUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        //book category button click event
        private void bkCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            //creating a new tab item with bkcategoryusercontrol as its content 
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Books' Categories",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            bkCategoryUserControl UC1 = new bkCategoryUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
