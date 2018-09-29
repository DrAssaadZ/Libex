using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Libex
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        //paths
        static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string appDirectoryPath = appDataPath + @"\Libex";
        static string dbDirectoryPath = appDirectoryPath + @"\Data Base";
        public static string settingDirectoryPath = appDirectoryPath + @"\Setting";        
        static string dataBasePath = dbDirectoryPath + @"\LibexDB.sdf";
        //GlobalVariables.coverPath = dbDirectoryPath + @"\coverImages";
        
        bool pathExists = Directory.Exists(appDirectoryPath);

        public SplashWindow()
        {
            
            //testing if the application is already runing
            if (Process.GetProcessesByName("Libex").Length > 1)
            {
                //Application is already running				
                MessageBox.Show("The Application is already running");
                Application.Current.Shutdown();
            }
            else
            {
                LoadSetting();
                //Only one instance of the application is running                 
                InitializeComponent();

                BackgroundWorker worker = new BackgroundWorker();
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerAsync();
            }            
        }

        //predefined function which is monituring the progress by the background worker 
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //nothing to initialize
        }

        //predefined function that does the work of the thread 
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GlobalVariables.coverPath = dbDirectoryPath + @"\coverImages";
            GlobalVariables.logoPath = settingDirectoryPath + @"\logo";
            //testing if the database is created or not
            if (!pathExists)
            {
                Directory.CreateDirectory(dbDirectoryPath);
                Directory.CreateDirectory(GlobalVariables.coverPath);
                Directory.CreateDirectory(GlobalVariables.logoPath);
                Thread.Sleep(200);
                Directory.CreateDirectory(settingDirectoryPath);
                Thread.Sleep(200);
                CreateSettingFile();                
                Thread.Sleep(200);
                File.Create(dataBasePath).Close();
                Thread.Sleep(200);

                try
                {
                    //creating the database along with the clients table 
                    SqlCeConnection dataBaseConnection = new SqlCeConnection(@"Data Source=" + dataBasePath + ";Max Database Size = 4091;");
                    string query = " CREATE TABLE Clients([Client ID] int PRIMARY KEY IDENTITY(1,1) , Name nvarchar(50), [Last Name] nvarchar(50), Gender nvarchar(10), [Age Period] nvarchar(15))";
                    SqlCeCommand cmd = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating selling books table
                    query = " CREATE TABLE SBooks([SBook ID] int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), [Book Edition] int, [Number of Pages] int, Author nvarchar(20), [Book Rating] int, Audience nvarchar(15), [Copyright Holder] nvarchar(20), Editor nvarchar(20), Genre nvarchar(20), Price real, Language nvarchar(15), Illustrator nvarchar(20), Cover nvarchar(100), Quantity int, About nvarchar(500))";
                    SqlCeCommand cmd2 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd2.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating renting books table
                    query = " CREATE TABLE RBooks([RBook ID] int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), [Book Edition] int, [Number of Pages] int, Author nvarchar(20), [BookRating] int, Audience nvarchar(15), [Copyright Holder] nvarchar(20), Editor nvarchar(20), Genre nvarchar(20), Price real, Language nvarchar(15), Illustrator nvarchar(20), Cover nvarchar(100), About nvarchar(500), Status nvarchar(10))";
                    SqlCeCommand cmd3 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd3.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating sells table
                    query = " CREATE TABLE Sells(SellID int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), Genre nvarchar(20),Price real, [Sell Date] datetime, [Client Age] nvarchar(10))";
                    SqlCeCommand cmd4 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd4.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating renting rents table
                    query = " CREATE TABLE Rents([RentID] int PRIMARY KEY IDENTITY(1,1) , [Book ID] int, [Client ID] int,Status nvarchar(20),Price real, [Rent Day] datetime, [Return Day] datetime)";
                    SqlCeCommand cmd5 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd5.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //adding foreign key1
                    query = "ALTER TABLE Rents ADD CONSTRAINT [Book ID] FOREIGN KEY ([Book ID]) REFERENCES RBooks([RBook ID])";
                    SqlCeCommand cmd6 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd6.ExecuteNonQuery();
                    dataBaseConnection.Close();

                    //adding foreign key2
                    query = "ALTER TABLE Rents ADD CONSTRAINT [Client ID] FOREIGN KEY ([Client ID]) REFERENCES Clients([Client ID])";
                    SqlCeCommand cmd7 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd7.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    query = " CREATE TABLE commands(cmID int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), Author nvarchar(20), Price real, [Client ID] int, Language nvarchar(15), Edition int)";
                    SqlCeCommand cmd8 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd8.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    query = "ALTER TABLE commands ADD CONSTRAINT [Client ID] FOREIGN KEY ([Client ID]) REFERENCES Clients([Client ID])";
                    SqlCeCommand cmd9 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd9.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);
                   
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("An erreur has been accured,\n please restart the application");
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }
        }

        //predefined function that shows the logging window when the backgroundworker is done 
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(2000);
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Close();
        }

        private void CreateSettingFile()
        {
            //initializing xml document object that we need to create all the nodes and setting the root node
            XmlDocument document = new XmlDocument();
            XmlNode RootElement = document.CreateElement("App");
            document.AppendChild(RootElement);
            // creating the links node and appending it to the root node (app)
            XmlNode linksNode = document.CreateElement("Links");
            RootElement.AppendChild(linksNode);
            //creating the logo note and appending it to the links node
            XmlNode logoNode = document.CreateElement("Logo");
            logoNode.InnerText = "0";
            linksNode.AppendChild(logoNode);
            //creating the settings node 
            XmlNode settingNode = document.CreateElement("Settings");
            RootElement.AppendChild(settingNode);
            //creating the theme node 
            XmlNode themeNode = document.CreateElement("Theme");
            themeNode.InnerText = "Blue";
            settingNode.AppendChild(themeNode);
            //creating the language node 
            XmlNode languageNode = document.CreateElement("Language");
            languageNode.InnerText = "En";
            settingNode.AppendChild(languageNode);
            //creating the startwith windows node 
            XmlNode startWithWindowsNode = document.CreateElement("StartWithWindows");
            startWithWindowsNode.InnerText = "0";
            settingNode.AppendChild(startWithWindowsNode);
            //creating the libary name node 
            XmlNode LibraryNameNode = document.CreateElement("LibraryName");
            settingNode.AppendChild(LibraryNameNode);
            //creating the address node 
            XmlNode AddressNode = document.CreateElement("Address");
            settingNode.AppendChild(AddressNode);
            //creating the owner node 
            XmlNode OwnerNOde = document.CreateElement("Owner");
            settingNode.AppendChild(OwnerNOde);
            //creating the phone node 
            XmlNode phoneNode = document.CreateElement("Phone");
            settingNode.AppendChild(phoneNode);
            //creating the email node 
            XmlNode mailNode = document.CreateElement("Email");
            settingNode.AppendChild(mailNode);
            //saving the xml document 
            document.Save(settingDirectoryPath + @"\Settings.xml");
        }

        //loading application settings
        public void LoadSetting()
        {
            if (!pathExists)
            {
                //appling blue theme on button click                
                    this.Resources.MergedDictionaries.Clear();
                    AddResourceDictionary("Resources/BlueAmberTheme.xaml");
                    AddResourceDictionary("Resources/englishDict.xaml");

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(settingDirectoryPath + @"\Settings.xml");
                string theme = doc.SelectSingleNode("//Theme").InnerText;
                doc.Load(settingDirectoryPath + @"\Settings.xml");
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
        }
        //adding a resource dictionnary 
        public void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
