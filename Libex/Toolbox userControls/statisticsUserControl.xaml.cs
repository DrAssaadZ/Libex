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
    /// Interaction logic for statisticsUserControl.xaml
    /// </summary>
    public partial class statisticsUserControl : UserControl
    {
        public statisticsUserControl()
        {
            InitializeComponent();
        }

        //client analytics button click event
        private void clientAnalBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();
          
            TabItem newTabItem = new TabItem{Header = "Clients Analytics",
                                             };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            clientAnalyticsUserControl UC1 = new clientAnalyticsUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;

        }

        //books analytics button click event
        private void bookAnalBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Books Analytics",
            };

            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            bookAnalyticsUserControl UC1 = new bookAnalyticsUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;

        }       
    }
}
