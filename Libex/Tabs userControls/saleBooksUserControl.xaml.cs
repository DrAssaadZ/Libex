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
    /// Interaction logic for saleBooksUserControl.xaml
    /// </summary>
    public partial class saleBooksUserControl : UserControl
    {
        public saleBooksUserControl()
        {
            InitializeComponent();
        }

        //grid view  toggle button checked event
        private void saleBookViewBtn_Checked(object sender, RoutedEventArgs e)
        {
            saleBookUserControlMainGrid.Children.Clear();
            saleBookUserControlMainGrid.Children.Add(new saleBookLargeViewUserControl());
        }

        //large view toggle button unchecked event
        private void saleBookViewBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            saleBookUserControlMainGrid.Children.Clear();
            saleBookUserControlMainGrid.Children.Add(new saleBookGridViewUserControl());
        }

        //showing the grid view of the books when the tab is created as default view
        private void saleBookUserControlMainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            saleBookUserControlMainGrid.Children.Clear();
            saleBookUserControlMainGrid.Children.Add(new saleBookGridViewUserControl());
        }

        //add new book button click event
        private void addSBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Add a book",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            addSBookUserControl UC1 = new addSBookUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
