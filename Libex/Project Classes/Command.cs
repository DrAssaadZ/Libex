using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libex.Project_Classes
{
    class Command
    {        
        int clientId;
        string bookTitle;       
        int bookYearEdition;
        string bookLang;
        string bookAuthor;
        float price;

        //order class constructor
        public Command(int ClientID ,string book_title, int edition_year, string book_language, string book_author, float book_price)
        {
            this.clientId = ClientID;
            this.bookTitle = book_title;           
            this.bookYearEdition = edition_year;
            this.bookLang = book_language;
            this.bookAuthor = book_author;
            this.price = book_price;
        }

        //method that adds an order to the commands database
        public void addAnOrder()
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "INSERT INTO commands([Client ID],[Book Name], Author,Price,Language,Edition) VALUES (@clientID,@bookName, @author,@price,@language,@edition)";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@bookName", this.bookTitle);
            cmd.Parameters.AddWithValue("@clientID", this.clientId);
            cmd.Parameters.AddWithValue("@edition", this.bookYearEdition);            
            cmd.Parameters.AddWithValue("@language", this.bookLang);
            cmd.Parameters.AddWithValue("@author", this.bookAuthor);
            cmd.Parameters.AddWithValue("@price", this.price);
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();
        }
    }   
}
