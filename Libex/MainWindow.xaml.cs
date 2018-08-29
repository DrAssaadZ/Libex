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
            maxAppBtn.Visibility = Visibility.Collapsed;
            restoreAppBtn.Visibility = Visibility.Visible;
        }
        //show the restore down button on top of the window when it is maximized without the max button
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                restoreAppBtn.Visibility = Visibility.Visible;
                maxAppBtn.Visibility = Visibility.Collapsed;
            }
        }

        //restore minimize window
        private void restoreAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            restoreAppBtn.Visibility = Visibility.Collapsed;
            maxAppBtn.Visibility = Visibility.Visible;
        }

        //turns the open menu button unchecked 
        private void DrawerHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            openMenuBtn.IsChecked = false;
        }
       
        //left mouse clicked on the top color zone event
        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        //minimize button click event
        private void minAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void tealAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/TealAmberTheme.xaml");            
        }

        private void blueGreyBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
        }


        private void blueAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueAmberTheme.xaml");
        }

        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void usercontrolShowBtn_Click(object sender, RoutedEventArgs e)
        {
            userControlGrid.Children.Clear();
            TestUserControl UC1 = new TestUserControl();
            userControlGrid.Children.Add(UC1);
            UC1.Visibility = System.Windows.Visibility.Visible;
        }
        //public TabControl tbControl;
        private void myTab_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalVariables.tbControl = (sender as TabControl);
        }

        //method that shows which menu item is selected
        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int listItemSelectedIndex = MenuList.SelectedIndex;
            MoveCursorMenu(listItemSelectedIndex);
        }

        //method that moves the cursor on the menu based on selection 
        private void MoveCursorMenu(int listItemSelectedIndex)
        {
            //transitioningContentSlide.OnApplyTemplate();
            MenuCursor.Margin = new Thickness(0, (117.5 + (50 * listItemSelectedIndex)), 0, 0);
        }

        
    }
}
