using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace Libex
{
    /// <summary>
    /// Interaction logic for clientAnalyticsUserControl.xaml
    /// </summary>
    public partial class clientAnalyticsUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public clientAnalyticsUserControl()
        {
            InitializeComponent();
            //first chart
            initializeGenderChart();
            //second chart
            ageChartItnit();
            //third chart
            ctegoryXageInit();
            //data binding
            DataContext = this;

        }

        #region gender chart
        //gender chart event
        public Func<ChartPoint, string> PointLabel { get; set; }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        //gender chart init
        public void initializeGenderChart()
        {
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            string query = "SELECT COUNT (*) FROM Clients WHERE Gender = 'Male'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int maleCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE Gender = 'Female'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int femaleCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            malepercentage.Values = new ChartValues<int> { maleCount };
            femalepercentage.Values = new ChartValues<int> { femaleCount };
            femalepercentage.Fill = (Brush)FindResource("SecondaryAccentBrush");
            malepercentage.Fill = (Brush)FindResource("PrimaryHueMidBrush");
        }
        #endregion

        #region age chart
        //initializing component of the chart
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        //age chart init
        public void ageChartItnit()
        {
            string query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Kid'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int kidCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Teenager'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int teenCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Young Adult'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int yAdCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Adult'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int adultCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Mid aged'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mAgeCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Clients WHERE [Age Period] = 'Elderly'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int oldCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Number",
                    Values = new ChartValues<double> { kidCount, teenCount, yAdCount, adultCount, mAgeCount, oldCount}
                }
            };
            Labels = new[] { "Kid", "Teenager", "Young Adult", "adult", "Mid Aged", "Elderly" };
            Formatter = value => value.ToString("N");
        }
        #endregion

        #region category chart
        //initializing components of the category chart
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter1 { get; set; }
        //category chart init
        public void ctegoryXageInit()
        {
            string query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Kid'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int kidCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Teenager'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int teenCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Young Adult'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int yAdCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Adult'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int adultCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Mid aged'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mAgeCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM Sells WHERE [Client Age] = 'Elderly'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int oldCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection1 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Number",
                    Values = new ChartValues<double> { kidCount, teenCount, yAdCount, adultCount, mAgeCount, oldCount}
                }
            };
            Labels1 = new[] { "Kid", "Teenager", "Young Adult", "adult", "Mid Aged", "Elderly" };
            Formatter1 = value => value.ToString("N");
        }
        #endregion        
    }
}
