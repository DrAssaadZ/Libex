using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libex
{
    class Rent
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        int RBookId;
        int CId;
        string status;
        float RBPrice;
        DateTime ReturnDAy;        

        //constructor
        public Rent(int bookID, int ClientID,float price, string status, DateTime returnDay)
        {
            this.RBookId = bookID;
            this.CId = ClientID;
            this.status = status;
            this.ReturnDAy = returnDay;
            this.RBPrice = price; 
        }

        //method that fills the rent database 
        public void RentAbook()
        {
            string query = "INSERT INTO Rents ([Book ID],[Client ID],status,Price,[Rent Day],[Return Day]) VALUES (@bookID,@clientID,@status,@price,@rentDay,@returnDay)";
            SqlCeCommand cmd = new SqlCeCommand(query,databaseConnection);
            cmd.Parameters.AddWithValue("@bookID",this.RBookId);
            cmd.Parameters.AddWithValue("@clientID", this.CId);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@price", this.RBPrice);
            cmd.Parameters.AddWithValue("@rentDay", DateTime.Today);
            cmd.Parameters.AddWithValue("@returnDay", this.ReturnDAy);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();

            //updating the status in the book 
            string query2 = "UPDATE RBooks SET [Status] = @newStatus WHERE [RBook ID] ='" + this.RBookId + "'";
            SqlCeCommand cmd2 = new SqlCeCommand(query2, databaseConnection);
            cmd2.Parameters.AddWithValue("@newStatus","Rent");
            databaseConnection.Open();
            cmd2.ExecuteNonQuery();
            databaseConnection.Close();
        }
    }
}
