using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libex
{
    class Client
    {
        string CName;
        string CFName;
        string CGender;
        string CAgePeriod;

        //constructor
        public Client(string name, string lname, string gender, string age)
        {
            this.CName = name;
            this.CFName = lname;
            this.CGender = gender;
            this.CAgePeriod = age;
        }

        //method that inserts a client in the client database
        public  void insertClient()
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "INSERT INTO Clients([Name], [Last Name],Gender,[Age Period]) VALUES (@name, @lname,@gender,@age)";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@name",this.CName);
            cmd.Parameters.AddWithValue("@lname",this.CFName);
            cmd.Parameters.AddWithValue("@gender",this.CGender);
            cmd.Parameters.AddWithValue("@age",this.CAgePeriod);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();
        }        
    }   
}
