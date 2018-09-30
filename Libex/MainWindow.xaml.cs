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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;


namespace Libex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region variables
        //creating the icon tray object
        System.Windows.Forms.NotifyIcon IconNotify;

        //dispatcher timer variable for the slideshow 
        DispatcherTimer dispatcher = new DispatcherTimer();

        //image number for the slide show 
        private int imageNumber = 1; 
        #endregion

        //main window
        public MainWindow()
        {
            LoadMainWindowSetting();
            InitializeComponent();
            tabControlDragable.Width = this.Width;
        }

        #region Window State button event methods
        //exit application button click
        private void exitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //max application button click
        private void maxAppBtn_Click(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
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
            tabControlDragable.Width = this.Width;
        }

        //minimize button click event
        private void minAppBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //left mouse clicked on the top color zone event
        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //window size event , it changes the size of the tab control based on the window size 
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tabControlDragable.Width = this.Width;
        }
        #endregion

        #region theme button event methods 
        //appling green theme on button click 
        private void tealAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/TealAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Green";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        //appling blue grey them on button click
        private void blueGreyBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Gray";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        //appling blue theme on button click
        private void blueAmberBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            AddResourceDictionary("Resources/BlueAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Blue";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        //adding a resource dictionnary 
        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
        #endregion

        #region open and close menu look adjust
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

        //turns the open menu button unchecked 
        private void DrawerHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            openMenuBtn.IsChecked = false;
        }
        #endregion

        #region Menu Methods
        //method that shows which menu item is selected
        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //the selected item
            int listItemSelectedIndex = MenuList.SelectedIndex;
            MoveCursorMenu(listItemSelectedIndex);

            //changing the user controls on list item clicks
            switch (listItemSelectedIndex)
            {
                case 0:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new DashBoardUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 1:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new statisticsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 2:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new ClientsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 3:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new bookUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 4:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new OrdersUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 5:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new ReturnedBooksUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 6:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new SellsAndRentsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                case 7:
                    gridMenu.Children.Clear();
                    gridMenu.Children.Add(new SettingsUserControl());
                    //close automaticly the list menu after chosing an item
                    closeMenuBtn.Command.Execute(closeMenuBtn.Command);
                    openMenuBtn.IsChecked = false;
                    break;
                default:
                    break;
            }
        }

        //method that moves the cursor on the menu based on selection 
        private void MoveCursorMenu(int listItemSelectedIndex)
        {
            //transitioningContentSlide.OnApplyTemplate();
            MenuCursor.Margin = new Thickness(0, (117.5 + (50 * listItemSelectedIndex)), 0, 0);
        }
        #endregion

        #region slideShow Methods
        //dispatcher time of the image slide show initializing 
        private void DispatcherTimerSlideShow()
        {

            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Start();

        }

        //changing images in every tick of the dispatcher timer 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            loadNextImage();
        }

        //activatin the slideshow when the expander is expended 
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSlideShow();
        }

        //stopping the slideshow when the expander is collapsed
        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            dispatcher.Stop();
        }

        //loading the next image
        private void loadNextImage()
        {
            if (imageNumber == 4)
            {
                imageNumber = 1;
            }
            string temp = string.Format(@"Resources\{0}.PNG", imageNumber);
            BitmapImage img = new BitmapImage(new Uri(temp, UriKind.Relative));

            img.UriSource = new Uri(temp, UriKind.Relative);
            SlideShowImageContainer.Source = new BitmapImage(new Uri(temp, UriKind.Relative));
            imageNumber++;
        }
        #endregion

        #region welcome part button events
        //get started button event in the WELCOME expander
        private void getStartedBtn_Click(object sender, RoutedEventArgs e)
        {
            openMenuBtn.Command.Execute(openMenuBtn.Command);
            closeMenuBtn.IsChecked = true;
        }

        //settings button click event in the welcome tab 
        private void settingBtnInWelcomeTab_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new SettingsUserControl());
        }

        //statistics button click event in the welcome tab
        private void statisticsBtnInWelcomeTab_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new statisticsUserControl());
        }
        #endregion

        #region tab control init
        //tab control init
        private void tabControlDragable_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalVariables.tbControl = (sender as TabControl);
        }
        #endregion

        #region application default setting
        //loading setting to the main window
        public void LoadMainWindowSetting()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            string theme = doc.SelectSingleNode("//Theme").InnerText;
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            string lang = doc.SelectSingleNode("//Language").InnerText;

            switch (lang)
            {
                case "En":
                    this.Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/englishDict.xaml");
                    break;
                case "Fr":
                    this.Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/frenchDict.xaml");
                    break;
                case "Ar":
                    this.Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/arabDict.xaml");
                    break;
                default:
                    this.Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/englishDict.xaml");
                    break;
            }

            switch (theme)
            {
                case "Blue":
                    this.Resources.MergedDictionaries.Clear();

                    AddResourceDictionary("Resources/BlueAmberTheme.xaml");
                    break;
                case "Green":
                    this.Resources.MergedDictionaries.Clear();

                    AddResourceDictionary("Resources/TealAmberTheme.xaml");
                    break;
                case "Gray":
                    this.Resources.MergedDictionaries.Clear();

                    AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
                    break;

                default:
                    this.Resources.MergedDictionaries.Clear();

                    AddResourceDictionary("Resources/BlueAmberTheme.xaml");
                    break;
            }
        } 
        #endregion

        #region tray methods
        //minimize to tray button click event
        private void minimizeToTray_Click(object sender, RoutedEventArgs e)
        {
            //creating the tray icon 
            IconNotify = new System.Windows.Forms.NotifyIcon();
            IconNotify.Icon = new System.Drawing.Icon("../../Resources/appIcon.ico");
            IconNotify.Visible = true;
            IconNotify.MouseClick += new System.Windows.Forms.MouseEventHandler(icon_click);
            IconNotify.ShowBalloonTip(500, "Minimized", "Libex has been minimized to tray", System.Windows.Forms.ToolTipIcon.Info);
            //creating the tray icon contextual menu 
            System.Windows.Forms.ContextMenu trayMenu = new System.Windows.Forms.ContextMenu();
            trayMenu.MenuItems.Add("Settings", new EventHandler(Setting));
            trayMenu.MenuItems.Add("Exit App", new EventHandler(ExitApp));
            IconNotify.ContextMenu = trayMenu;

            //minimizing the app when minimize to tray button is clicked 
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
        }


        //setting app tray item clicked
        private void Setting(object sender, EventArgs e)
        {
            //restoring window state after left mouse click on the tray icon
            this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = true;
            //focus the app after being restored from the tray
            this.Activate();
            //showing the setting tab user control
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new SettingsUserControl());
            IconNotify.Dispose();
        }

        //exit app tray item clicked 
        private void ExitApp(object sender, EventArgs e)
        {
            //exiting the application when the exit app item is chosen
            Application.Current.Shutdown();
            IconNotify.Dispose();
        }

        //tray icon clicked event 
        private void icon_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //left mouse click 
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //restoring window state after left mouse click on the tray icon
                this.WindowState = WindowState.Normal;
                this.ShowInTaskbar = true;
                //focus the app after being restored from the tray
                this.Activate();
                IconNotify.Dispose();
            }
        } 
        #endregion

    }
}
