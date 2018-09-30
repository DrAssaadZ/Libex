using Libex.Project_Classes;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for BookModelUserControl.xaml
    /// </summary>
    public partial class BookModelUserControl : UserControl
    {
        //constructor
        public BookModelUserControl(string Bname, string AuthName , string ImgCov,string ISBN,int Edition,string Editor,string Genre,float Price, string About)
        {
            InitializeComponent();
            bookNameBox.Text = Bname;
            authorBox.Text = AuthName;
            coverBox.Source = new BitmapImage(new Uri(ImgCov));
            ISBNBox.Text = ISBN;
            EditionBox.Text = Edition.ToString();
            EditorBox.Text = Editor;
            GenreBox.Text = Genre;
            PriceBox.Text = Price.ToString();
            AboutBox.Text = About;
        }
    }
}
