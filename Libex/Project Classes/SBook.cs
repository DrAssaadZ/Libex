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
    class SBook
    {
        //vars
        string SBookName;
        string SBookISBN;
        int SBookEdition;
        int SBookPageNum;
        string SBookAuthor;
        int SBookRating;
        string SBookAudience;
        string SBookCopyRightsHolder;
        string SBookEditor;
        string SbookGenre;
        float SBookPrice;
        string SBookLang;
        string SBookIllustrator;
        int SBookQuantity;
        string AboutBook;
        ImageSource SBookCover;
        
        //sale book constructor
        public SBook(string saleBookName, string saleBookISBN, int saleBookEdition, int saleBookNbrPage, string saleBookAuthor,
            string saleBookAudience, string saleBookCopyrightHolder, string saleBookEditor, string saleBookGenre, float saleBookPrice,
            string saleBookLanguage, string saleBookIllustrator, int saleBookQuantity, int saleBookRating,ImageSource coverImage,string About)
        {
            this.SBookName = saleBookName;
            this.SBookISBN = saleBookISBN;
            this.SBookEdition = saleBookEdition;
            this.SBookPageNum = saleBookNbrPage;
            this.SBookAuthor = saleBookAuthor;
            this.SBookRating = saleBookRating;
            this.SBookAudience = saleBookAudience;
            this.SBookCopyRightsHolder = saleBookCopyrightHolder;
            this.SBookEditor = saleBookEditor;
            this.SbookGenre = saleBookGenre;
            this.SBookPrice = saleBookPrice;
            this.SBookLang = saleBookLanguage;
            this.SBookQuantity = saleBookQuantity;
            this.AboutBook = About;
            this.SBookIllustrator = saleBookIllustrator;
            this.SBookCover = coverImage;
        }

        //method that adds a sale book after taking user input
        public void insertSaleBook()
        {
            SqlCeConnection databaseConnection = new SqlCeConnection(GlobalVariables.databasePath);
            string query = "INSERT INTO SBooks([Book Name],[Book ISBN],[Book Edition],[Number of Pages],[Author],[Book Rating],[Audience],[Copyright Holder]," +
                "[Editor],[Genre],[Price],[Language],[Illustrator],[Quantity],[About],[Cover]) " +
                "VALUES (@bookName, @ISBN, @bookEdition, @pageNbr, @author, @rating, @audience, @copyrightHolder, @editor, @genre, @price, @language, " +
                "@illustrator, @quantity, @about, @imgcover)";
            SqlCeCommand cmd = new SqlCeCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@bookName", this.SBookName);
            cmd.Parameters.AddWithValue("@ISBN", this.SBookISBN);
            cmd.Parameters.AddWithValue("@bookEdition", this.SBookEdition);
            cmd.Parameters.AddWithValue("@pageNbr", this.SBookPageNum);
            cmd.Parameters.AddWithValue("@author", this.SBookAuthor);
            cmd.Parameters.AddWithValue("@rating", this.SBookRating);
            cmd.Parameters.AddWithValue("@audience", this.SBookAudience);
            cmd.Parameters.AddWithValue("@copyrightHolder", this.SBookCopyRightsHolder);
            cmd.Parameters.AddWithValue("@editor", this.SBookEditor);
            cmd.Parameters.AddWithValue("@genre", this.SbookGenre);
            cmd.Parameters.AddWithValue("@price", this.SBookPrice);
            cmd.Parameters.AddWithValue("@language", this.SBookLang);
            cmd.Parameters.AddWithValue("@illustrator", this.SBookIllustrator);
            cmd.Parameters.AddWithValue("@quantity", this.SBookQuantity);
            cmd.Parameters.AddWithValue("@about", this.AboutBook);
            cmd.Parameters.AddWithValue("imgcover", GlobalVariables.coverPath + @"\" + this.SBookName + ".png");           
            databaseConnection.Open();
            cmd.ExecuteNonQuery();
            databaseConnection.Close();
            //filestream to save the browsed image to the coverpath in appdata
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)this.SBookCover));
            using (FileStream stream = new FileStream(GlobalVariables.coverPath + @"\" + this.SBookName + ".png" , FileMode.Create))
                encoder.Save(stream);
        }
    }
}
