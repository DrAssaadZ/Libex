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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //color zone mouse down drag and move
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // open menu click event
        private void openMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            closeMenuBtn.IsChecked = true;
        }

        //close menu click event
        private void closeMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            openMenuBtn.IsChecked = false;
        }

        //exit application button click
        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //max application button click
        private void maxAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

        }
    }
}
