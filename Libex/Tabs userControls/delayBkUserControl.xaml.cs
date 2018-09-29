﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace Libex
{
    /// <summary>
    /// Interaction logic for delayBkUserControl.xaml
    /// </summary>
    public partial class delayBkUserControl : UserControl
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        public delayBkUserControl()
        {
            InitializeComponent();
            fillDelayedBooksGrid();
        }

        //method that fills the delayed data  books grid
        public void fillDelayedBooksGrid()
        {
            string query = "SELECT * FROM Rents WHERE [Return Day] > '" + DateTime.Today + "'";
            SqlCeDataAdapter adapt = new SqlCeDataAdapter(query, databaseConnection);
            databaseConnection.Open();
            DataTable booksD = new DataTable();
            adapt.Fill(booksD);
            delayedBooksDataGrid.ItemsSource = booksD.DefaultView;
            databaseConnection.Close();
        }
    }
}
