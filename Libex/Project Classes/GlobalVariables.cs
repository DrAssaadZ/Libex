using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Libex
{
   class GlobalVariables
    {        
        public static TabControl tbControl;
        public static string databasePath = @"Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Libex\Data Base\LibexDB.sdf";
        public static string coverPath;
        public static string logoPath;
        public static DataRowView dataRowView;
        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string appDirectoryPath = appDataPath + @"\Libex";
    }
}
