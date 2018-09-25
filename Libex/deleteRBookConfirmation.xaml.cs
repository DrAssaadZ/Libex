﻿using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
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
using System.Windows.Shapes;

namespace Libex
{
    /// <summary>
    /// Interaction logic for deleteRBookConfirmation.xaml
    /// </summary>
    public partial class deleteRBookConfirmation : Window
    {
        public deleteRBookConfirmation()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "DELETE FROM RBooks WHERE [RBook ID] = '" + GlobalVariables.dataRowView[0] + "'";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();

            File.Delete(GlobalVariables.coverPath + @"\" + GlobalVariables.dataRowView[1] + ".png");

            this.Close();
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
