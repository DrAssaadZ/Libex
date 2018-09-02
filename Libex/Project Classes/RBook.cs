using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Libex
{
    class RBook
    {
        int RBookId;
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
        string RBookLang;
        string RBookIllustrator;
        string RBookQuantity;
        BitmapImage RBookCover;
        //ADditional inforamtion
        string RBookStatus;
        DateTime RBookRentDAte;
        DateTime RBookReturnDAte;

        public RBook()
        {

        }
    }
}
