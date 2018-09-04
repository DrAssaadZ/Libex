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
using Libex.Tabs_userControls;

namespace Libex
{
    /// <summary>
    /// Interaction logic for listOrdersUserControl.xaml
    /// </summary>
    public partial class listOrdersUserControl : UserControl
    {
        public listOrdersUserControl()
        {
            InitializeComponent();
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Add an Order",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            addOrderUserControl UC1 = new addOrderUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
