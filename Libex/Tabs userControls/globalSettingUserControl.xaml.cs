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
using System.Xml;
using Microsoft.Win32;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;


namespace Libex
{
    /// <summary>
    /// Interaction logic for globalSettingUserControl.xaml
    /// </summary>
    public partial class globalSettingUserControl : UserControl
    {
        public globalSettingUserControl()
        {
            
            InitializeComponent();
            startWWinState();
        }

        #region change theme methods
        //adding a resource dictionnary 
        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        // blue amber button click event
        private void blueBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/BlueAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Blue";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        //teal amber button click event
        private void tealBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/TealAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Green";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        //blue grey amber button click event
        private void blueGBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/BlueGreyAmberTheme.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Theme");
            ThemeNode.InnerText = "Gray";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }
        #endregion


        #region start with windows methods
        //start with windows toggle button checked
        private void startWWinBtn_Checked(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode startNode = doc.SelectSingleNode("//StartWithWindows");
            startNode.InnerText = "1";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");

            //access regesitry to make the app start with windows
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("Libex", System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        //start with window toggle button unckecked event
        private void startWWinBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode startNode = doc.SelectSingleNode("//StartWithWindows");
            startNode.InnerText = "0";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");

            //access regesitry to make the app stop starting with windows
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("Libex", false);
        }

        //this function set the state of the toggle button of start with windows according to the setting file
        private void startWWinState()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            int startState = int.Parse(doc.SelectSingleNode("//StartWithWindows").InnerText);

            if (startState == 0)
            {
                startWWinBtn.IsChecked = false;
            }
            else
            {
                startWWinBtn.IsChecked = true;
            }
        }
        #endregion

        #region backup methods
        private void seletDirBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();
                directoryBox.Text = fbd.SelectedPath;
            }
        }

        //create backup button click event
        private void createBkupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (directoryBox.Text != "")
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {
                    //select the path to zip
                    zip.AddDirectory(GlobalVariables.appDirectoryPath);
                    //save the ziped file
                    zip.Save(directoryBox.Text + @"\BackUp.zip");
                }
            }
            else
            {
                MessageBox.Show("Select a directory first");
            }
        } 
        #endregion

        #region change language methods
        private void EnBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/englishDict.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Language");
            ThemeNode.InnerText = "En";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        private void FrBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/frenchDict.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Language");
            ThemeNode.InnerText = "Fr";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }

        private void ArBtn_Click(object sender, RoutedEventArgs e)
        {
            AddResourceDictionary("Resources/arabDict.xaml");
            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode ThemeNode = doc.SelectSingleNode("//Language");
            ThemeNode.InnerText = "Ar";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        } 
        #endregion
    }
}
