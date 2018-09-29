using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Libex
{
    class RBook
    {        
        string RBookName;
        string RBookISBN;
        int RBookEdition;
        int RBookPageNum;
        string RBookAuthor;
        int RBookRating;
        string RBookAudience;
        string RBookCopyRightsHolder;
        string RBookEditor;
        string RbookGenre;
        float RBookRentPrice;
        string RBookIllustrator;        
        string RBookLanguage;
        string AboutBook;
        ImageSource RBookCover;
        //ADditional inforamtion
        string RBookStatus;
        
        //rent book class constructor
        public RBook(string rentBookName, string rentBookISBN, int rentBookEdition, int rentBookNbrPage, string rentBookAuthor,
            string rentBookAudience, string rentBookCopyrightHolder, string rentBookEditor, string rentBookGenre, float rentBookPrice,
            string rentBookLanguage, string rentBookIllustrator, int rentBookRating, ImageSource coverImage, string About)
        {
            this.RBookName = rentBookName;
            this.RBookISBN = rentBookISBN;
            this.RBookEdition = rentBookEdition;
            this.RBookPageNum = rentBookNbrPage;
            this.RBookAuthor = rentBookAuthor;
            this.RBookRating = rentBookRating;
            this.RBookAudience = rentBookAudience;
            this.RBookCopyRightsHolder = rentBookCopyrightHolder;
            this.RBookEditor = rentBookEditor;
            this.RbookGenre = rentBookGenre;
            this.RBookRentPrice = rentBookPrice;
            this.RBookLanguage = rentBookLanguage;            
            this.AboutBook = About;
            this.RBookIllustrator = rentBookIllustrator;
            this.RBookCover = coverImage;
        }

        public void insertRentBook()
        {
            if (RBookCover == null)
            {
                SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
                string query = "INSERT INTO RBooks([Book Name],[Book ISBN],[Book Edition],[Number of Pages],[Author],[BookRating],[Audience],[Copyright Holder]," +
                    "[Editor],[Genre],[Price],[Language],[Illustrator],[About],[Status]) " +
                    "VALUES (@bookName, @ISBN, @bookEdition, @pageNbr, @author, @rating, @audience, @copyrightHolder, @editor, @genre, @price, @language, " +
                    "@illustrator, @about,@status)";
                SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
                cmd.Parameters.AddWithValue("@bookName", this.RBookName);
                cmd.Parameters.AddWithValue("@ISBN", this.RBookISBN);
                cmd.Parameters.AddWithValue("@bookEdition", this.RBookEdition);
                cmd.Parameters.AddWithValue("@pageNbr", this.RBookPageNum);
                cmd.Parameters.AddWithValue("@author", this.RBookAuthor);
                cmd.Parameters.AddWithValue("@rating", this.RBookRating);
                cmd.Parameters.AddWithValue("@audience", this.RBookAudience);
                cmd.Parameters.AddWithValue("@copyrightHolder", this.RBookCopyRightsHolder);
                cmd.Parameters.AddWithValue("@editor", this.RBookEditor);
                cmd.Parameters.AddWithValue("@genre", this.RbookGenre);
                cmd.Parameters.AddWithValue("@price", this.RBookRentPrice);
                cmd.Parameters.AddWithValue("@language", this.RBookLanguage);
                cmd.Parameters.AddWithValue("@illustrator", this.RBookIllustrator);
                cmd.Parameters.AddWithValue("@about", this.AboutBook);
                cmd.Parameters.AddWithValue("@status", "Available");
                
                databaseConnection.Open();
                cmd.ExecuteNonQuery();
                databaseConnection.Close();
                
            }
            else
            {
                SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
                string query = "INSERT INTO RBooks([Book Name],[Book ISBN],[Book Edition],[Number of Pages],[Author],[BookRating],[Audience],[Copyright Holder]," +
                    "[Editor],[Genre],[Price],[Language],[Illustrator],[About],[Cover],[Status]) " +
                    "VALUES (@bookName, @ISBN, @bookEdition, @pageNbr, @author, @rating, @audience, @copyrightHolder, @editor, @genre, @price, @language, " +
                    "@illustrator, @about, @imgcover,@status)";
                SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
                cmd.Parameters.AddWithValue("@bookName", this.RBookName);
                cmd.Parameters.AddWithValue("@ISBN", this.RBookISBN);
                cmd.Parameters.AddWithValue("@bookEdition", this.RBookEdition);
                cmd.Parameters.AddWithValue("@pageNbr", this.RBookPageNum);
                cmd.Parameters.AddWithValue("@author", this.RBookAuthor);
                cmd.Parameters.AddWithValue("@rating", this.RBookRating);
                cmd.Parameters.AddWithValue("@audience", this.RBookAudience);
                cmd.Parameters.AddWithValue("@copyrightHolder", this.RBookCopyRightsHolder);
                cmd.Parameters.AddWithValue("@editor", this.RBookEditor);
                cmd.Parameters.AddWithValue("@genre", this.RbookGenre);
                cmd.Parameters.AddWithValue("@price", this.RBookRentPrice);
                cmd.Parameters.AddWithValue("@language", this.RBookLanguage);
                cmd.Parameters.AddWithValue("@illustrator", this.RBookIllustrator);
                cmd.Parameters.AddWithValue("@status", "Available");
                cmd.Parameters.AddWithValue("@about", this.AboutBook);
                cmd.Parameters.AddWithValue("imgcover", GlobalVariables.coverPath + @"\" + this.RBookName + ".png");
                databaseConnection.Open();
                cmd.ExecuteNonQuery();
                databaseConnection.Close();
                //filestream to save the browsed image to the coverpath in appdata
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)this.RBookCover));
                using (FileStream stream = new FileStream(GlobalVariables.coverPath + @"\" + this.RBookName + ".png", FileMode.Create))
                    encoder.Save(stream);
            }
        }

    }
}
