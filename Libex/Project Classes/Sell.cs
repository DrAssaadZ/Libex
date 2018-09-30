using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libex
{
    class Sell
    {
        SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
        string SBookName;
        string SBookISBN;
        string SbookGenre;
        float SBookPrice;
        string CAgePeriod;

        //constructor
        public Sell(string bookName, string bookISBN, string bookGenre, float bookPrice,string agePeriod)
        {
            this.SBookName = bookName;
            this.SBookISBN = bookISBN;
            this.SbookGenre = bookGenre;
            this.SBookPrice = bookPrice;
            this.CAgePeriod = agePeriod;
        }

        //method that adds a book to the sale book table 
        public void SellABook()
        {            
            string query = "INSERT INTO Sells([Book Name],[Book ISBN],Genre,Price,[Client Age],[Sell Date]) VALUES(@bookName,@isbn,@genre,@price,@clientAge,@sellDate)";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@bookName", this.SBookName);
            cmd.Parameters.AddWithValue("@isbn", this.SBookISBN);
            cmd.Parameters.AddWithValue("@genre", this.SbookGenre);
            cmd.Parameters.AddWithValue("@price", this.SBookPrice);
            cmd.Parameters.AddWithValue("@clientAge", this.CAgePeriod);
            cmd.Parameters.AddWithValue("@sellDate", DateTime.Today);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();

            //accessing the sold book current quantity 
            string query2 = "SELECT [Quantity] FROM SBooks WHERE [Book Name] = '" + this.SBookName + "'";            
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(query2,databaseConnection);
            DataTable data = new DataTable();
            databaseConnection.Open();
            adapter.Fill(data);
            string currentQuantity = data.Rows[0]["Quantity"].ToString();
            databaseConnection.Close();

            //updating the quantity of the sold book
            string query4 = "UPDATE SBooks SET [Quantity] = @newQuantity WHERE [Book Name] = @QbookName";
            SqlCeCommand cmd4 = new SqlCeCommand(query4, databaseConnection);
            cmd4.Parameters.AddWithValue("@QbookName",this.SBookName);
            int newQuantity = int.Parse(currentQuantity) - 1;
            cmd4.Parameters.AddWithValue("@newQuantity",newQuantity);
            databaseConnection.Open();
            cmd4.ExecuteNonQuery();
            databaseConnection.Close();

            //removing the book if its quantity is 0
            if (newQuantity == 0)
            {               
                string query3 = "DELETE FROM SBooks WHERE [Book Name] = '" + this.SBookName + "'";
                SqlCeCommand cmd3 = new SqlCeCommand(query3, databaseConnection);
                databaseConnection.Open();
                cmd3.ExecuteNonQuery();
                databaseConnection.Close();
            }
        }    
    }
}
