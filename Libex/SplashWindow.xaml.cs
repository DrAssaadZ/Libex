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
        static string settingDirectoryPath = appDirectoryPath + @"\Setting";
        static string backUpDirectoryPath = appDirectoryPath + @"\Backup";
        static string dataBasePath = dbDirectoryPath + @"\LibexDB.sdf";
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
            //testing if the database is created or not
            if (!pathExists)
            {
                Directory.CreateDirectory(dbDirectoryPath);
                Thread.Sleep(200);
                Directory.CreateDirectory(settingDirectoryPath);
                Thread.Sleep(200);
                Directory.CreateDirectory(backUpDirectoryPath);
                Thread.Sleep(200);
                File.Create(dataBasePath).Close();
                Thread.Sleep(200);

                try
                {
                    //creating the database along with the clients table 
                    SqlCeConnection dataBaseConnection = new SqlCeConnection(@"Data Source=" + dataBasePath + ";Max Database Size = 4091;");
                    string query = " CREATE TABLE Clients([Client ID] int PRIMARY KEY IDENTITY(1,1) , Name nvarchar(50), [Last Name] nvarchar(50), Gender nvarchar(10), [Age Period] nvarchar(10), Points int)";
                    SqlCeCommand cmd = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating selling books table
                    query = " CREATE TABLE SBooks([SBook ID] int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), [Book Edition] int, [Number of Pages] int, Author nvarchar(20), [Book Rating] int, Audience nvarchar(10), [Copyright Holder] nvarchar(20), Editor nvarchar(20), Genre nvarchar(10), Price real, Language nvarchar(15), Illustrator nvarchar(20), Cover image, Quantity int, About nvarchar(500))";
                    SqlCeCommand cmd2 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd2.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating renting books table
                    query = " CREATE TABLE RBooks([RBook ID] int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), [Book Edition] int, [Number of Pages] int, Author nvarchar(20), [BookRating] int, Audience nvarchar(10), [Copyright Holder] nvarchar(20), Editor nvarchar(20), Genre nvarchar(10), Price real, Language nvarchar(15), Illustrator nvarchar(20), Cover image, About nvarchar(500), Status nvarchar(10), [Rent DAy] datetime, [Return Date] datetime)";
                    SqlCeCommand cmd3 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd3.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating sells table
                    query = " CREATE TABLE Sells(SellID int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), [Book ISBN] nvarchar(20), Genre nvarchar(10), [Sell Date] datetime, [Client Age] nvarchar(10))";
                    SqlCeCommand cmd4 = new SqlCeCommand(query, dataBaseConnection);
                    dataBaseConnection.Open();
                    cmd4.ExecuteNonQuery();
                    dataBaseConnection.Close();
                    Thread.Sleep(200);

                    //Creating renting rents table
                    query = " CREATE TABLE Rents([RentID] int PRIMARY KEY IDENTITY(1,1) , [Book ID] int, [Client ID] int, [Rent Day] datetime, [Return Day] datetime)";
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

                    query = " CREATE TABLE commands(cmID int PRIMARY KEY IDENTITY(1,1) , [Book Name] nvarchar(50), Author nvarchar(20), Price real, [Client ID] int)";
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
                catch (Exception)
                {
                    MessageBox.Show("An erreur has been accured,\n please restart the application");
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
    }
}
