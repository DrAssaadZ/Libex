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
    /// Interaction logic for bookAnalyticsUserControl.xaml
    /// </summary>
    public partial class bookAnalyticsUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public bookAnalyticsUserControl()
        {
            InitializeComponent();
            //rent/sale chart
            initializeRentAndSAleChart();
            // for sale book category 
            ScategoryBookInit();
            //for sale book audience
            SaudienceBookItnit();
            //for rent book category
            RcategoryBookInit();
            //for rent book audience 
            RaudienceBookItnit();
            //binding data
            DataContext = this;
        }

        #region for sale book category chart
        //initializing components of the category chart
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter1 { get; set; }
        //category chart init
        public void ScategoryBookInit()
        {
            string query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Science Fiction'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int scienceFCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Drama'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int dramaCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Action/Adventure'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int acAdvCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Romance'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int romanceCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Mystery'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mysteryCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Fantasy'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int fantasyCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Biographies'";
            SqlCeCommand cmd7 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int biographyCount = (int)cmd7.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Trilogy'";
            SqlCeCommand cmd8 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int trilogyCount = (int)cmd8.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Series'";
            SqlCeCommand cmd9 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int seriesCount = (int)cmd9.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Journals'";
            SqlCeCommand cmd10 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int journCount = (int)cmd10.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Diaries'";
            SqlCeCommand cmd11 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int diaryCount = (int)cmd11.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Cookbooks'";
            SqlCeCommand cmd12 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int cookCount = (int)cmd12.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Art'";
            SqlCeCommand cmd13 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ArtCount = (int)cmd13.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Comics'";
            SqlCeCommand cmd14 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ComicCount = (int)cmd14.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Dictionaries'";
            SqlCeCommand cmd15 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int dictioCount = (int)cmd15.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Encyclopedias'";
            SqlCeCommand cmd16 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int encycloCount = (int)cmd16.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Math'";
            SqlCeCommand cmd17 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mathCount = (int)cmd17.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Religion'";
            SqlCeCommand cmd18 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int religionCount = (int)cmd18.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Science'";
            SqlCeCommand cmd19 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ScienceCount = (int)cmd19.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Health'";
            SqlCeCommand cmd20 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int healthCount = (int)cmd20.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'History'";
            SqlCeCommand cmd21 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int historyCount = (int)cmd21.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Self help'";
            SqlCeCommand cmd22 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int sHelpCount = (int)cmd22.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Genre] = 'Poetry'";
            SqlCeCommand cmd23 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int peotryCount = (int)cmd23.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection1 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Genre",
                    Values = new ChartValues<double> { scienceFCount, dramaCount, acAdvCount, romanceCount, mysteryCount, fantasyCount,biographyCount,trilogyCount,seriesCount,journCount
                                                        ,diaryCount,cookCount,ArtCount,ComicCount,dictioCount,encycloCount,mathCount,religionCount,ScienceCount,healthCount,historyCount,sHelpCount,peotryCount}
                }
            };
            Labels1 = new[] { "Science Fiction", "Drama", "Action/Adventure", "Romance", "Mystery", "Fantasy" , "Biographies" , "Trilogy" , "Series", "Journals", "Diaries" , "Cookbooks" ,
                            "Art","Comics", "Dictionaries","Encyclopedias", "Math", "Religion", "Health", "History", "Self Help", "Poetry"};
            Formatter1 = value => value.ToString("N");
        }
        #endregion

        #region for sale book audience chart 
        //initializing component of the chart
        public SeriesCollection SeriesCollection2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        //audience chart init
        public void SaudienceBookItnit()
        {
            string query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Kid'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int kidCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Teenager'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int teenCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Young Adult'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int yAdCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Adult'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int adultCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Mid aged'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mAgeCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM SBooks WHERE [Audience] = 'Elderly'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int oldCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection2 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Number",
                    Values = new ChartValues<double> { kidCount, teenCount, yAdCount, adultCount, mAgeCount, oldCount}
                }
            };
            Labels2 = new[] { "Kid", "Teenager", "Young Adult", "adult", "Mid Aged", "Elderly" };
            Formatter2 = value => value.ToString("N");
        }

        #endregion

        #region for rent book category chart
        //initializing components of the category chart
        public SeriesCollection SeriesCollection3 { get; set; }
        public string[] Labels3 { get; set; }
        public Func<double, string> Formatter3 { get; set; }
        public void RcategoryBookInit()
        {
            string query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Science Fiction'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int scienceFCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Drama'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int dramaCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Action/Adventure'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int acAdvCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Romance'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int romanceCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Mystery'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mysteryCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Fantasy'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int fantasyCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Biographies'";
            SqlCeCommand cmd7 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int biographyCount = (int)cmd7.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Trilogy'";
            SqlCeCommand cmd8 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int trilogyCount = (int)cmd8.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Series'";
            SqlCeCommand cmd9 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int seriesCount = (int)cmd9.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Journals'";
            SqlCeCommand cmd10 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int journCount = (int)cmd10.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Diaries'";
            SqlCeCommand cmd11 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int diaryCount = (int)cmd11.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Cookbooks'";
            SqlCeCommand cmd12 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int cookCount = (int)cmd12.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Art'";
            SqlCeCommand cmd13 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ArtCount = (int)cmd13.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Comics'";
            SqlCeCommand cmd14 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ComicCount = (int)cmd14.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Dictionaries'";
            SqlCeCommand cmd15 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int dictioCount = (int)cmd15.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Encyclopedias'";
            SqlCeCommand cmd16 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int encycloCount = (int)cmd16.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Math'";
            SqlCeCommand cmd17 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mathCount = (int)cmd17.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Religion'";
            SqlCeCommand cmd18 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int religionCount = (int)cmd18.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Science'";
            SqlCeCommand cmd19 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int ScienceCount = (int)cmd19.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Health'";
            SqlCeCommand cmd20 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int healthCount = (int)cmd20.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'History'";
            SqlCeCommand cmd21 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int historyCount = (int)cmd21.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Self help'";
            SqlCeCommand cmd22 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int sHelpCount = (int)cmd22.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Genre] = 'Poetry'";
            SqlCeCommand cmd23 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int peotryCount = (int)cmd23.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection3 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Genre",
                    Values = new ChartValues<double> { scienceFCount, dramaCount, acAdvCount, romanceCount, mysteryCount, fantasyCount,biographyCount,trilogyCount,seriesCount,journCount
                                                        ,diaryCount,cookCount,ArtCount,ComicCount,dictioCount,encycloCount,mathCount,religionCount,ScienceCount,healthCount,historyCount,sHelpCount,peotryCount}
                }
            };
            Labels3 = new[] { "Science Fiction", "Drama", "Action/Adventure", "Romance", "Mystery", "Fantasy" , "Biographies" , "Trilogy" , "Series", "Journals", "Diaries" , "Cookbooks" ,
                            "Art","Comics", "Dictionaries","Encyclopedias", "Math", "Religion", "Health", "History", "Self Help", "Poetry"};
            Formatter3 = value => value.ToString("N");
        }
        #endregion

        #region rent book audience chart
        //initializing components of the category chart
        public SeriesCollection SeriesCollection4 { get; set; }
        public string[] Labels4 { get; set; }
        public Func<double, string> Formatter4 { get; set; }
        //audience chart init
        public void RaudienceBookItnit()
        {
            string query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Kid'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int kidCount = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Teenager'";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int teenCount = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Young Adult'";
            SqlCeCommand cmd3 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int yAdCount = (int)cmd3.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Adult'";
            SqlCeCommand cmd4 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int adultCount = (int)cmd4.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Mid aged'";
            SqlCeCommand cmd5 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int mAgeCount = (int)cmd5.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks WHERE [Audience] = 'Elderly'";
            SqlCeCommand cmd6 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int oldCount = (int)cmd6.ExecuteScalar();
            databaseConnection.Close();

            SeriesCollection4 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Number",
                    Values = new ChartValues<double> { kidCount, teenCount, yAdCount, adultCount, mAgeCount, oldCount}
                }
            };
            Labels4 = new[] { "Kid", "Teenager", "Young Adult", "adult", "Mid Aged", "Elderly" };
            Formatter4 = value => value.ToString("N");
        }
        #endregion


        #region for rent/sale chart
        public Func<ChartPoint, string> PointLabel { get; set; }
        private void PieChart_DataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        public void initializeRentAndSAleChart()
        {
            PointLabel = chartPoint =>
              string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            string query = "SELECT COUNT (*) FROM SBooks ";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int forSaleNbr = (int)cmd.ExecuteScalar();
            databaseConnection.Close();

            query = "SELECT COUNT (*) FROM RBooks ";
            SqlCeCommand cmd2 = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            int forRentNbr = (int)cmd2.ExecuteScalar();
            databaseConnection.Close();

            forSalePercent.Values = new ChartValues<int> { forSaleNbr };
            forRentPercent.Values = new ChartValues<int> { forRentNbr };
            forRentPercent.Fill = (Brush)FindResource("SecondaryAccentBrush");
            forSalePercent.Fill = (Brush)FindResource("PrimaryHueMidBrush");
        }
        #endregion
    }
}
