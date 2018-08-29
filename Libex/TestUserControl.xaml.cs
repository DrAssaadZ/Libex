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
    /// Interaction logic for TestUserControl.xaml
    /// </summary>
    public partial class TestUserControl : UserControl
    {
        
        public TestUserControl()
        {
            InitializeComponent();
        }

        private void showGuestBtn_Click(object sender, RoutedEventArgs e)
        {

            Grid mygrid = new Grid();
            mygrid.Background = new SolidColorBrush(Colors.Black);

            TabItem newTabItem = new TabItem
            {
                Header = "it works",
                Name = "Test"

                
            };
            GlobalVariables.tbControl.Items.Add(newTabItem);
            newTabItem.Content = mygrid;
            mygrid.Children.Clear();
            secondUserControlTest UC1 = new secondUserControlTest();
            mygrid.Children.Add(UC1);
        }

        
    }
}
