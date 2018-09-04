using Libex.Tabs_userControls;
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
    /// Interaction logic for rentBooksUserControl.xaml
    /// </summary>
    public partial class rentBooksUserControl : UserControl
    {
        public rentBooksUserControl()
        {
            InitializeComponent();
        }


        //showing the grid view of the books when the tab is created as default view
        private void rentBookUserControlMainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(new rentBookGridViewUserControl());
        }
        //grid view  toggle button checked event
        private void saleBookViewBtn_Checked(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(new rentBookLargeViewUserControl());
        }

        //large view toggle button unchecked event
        private void saleBookViewBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            rentBookUserControlMainGrid.Children.Clear();
            rentBookUserControlMainGrid.Children.Add(new rentBookGridViewUserControl());

        }

        //rent a book button click event
        private void rentBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Rent a book",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            rentABookUserControl UC1 = new rentABookUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
