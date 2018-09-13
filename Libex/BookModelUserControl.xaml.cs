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
        public BookModelUserControl(string Bname, string AuthName , string ImgCov)
        {
            InitializeComponent();
            //giving the book binding imformation to the context 
            this.DataContext = new BookBindingInformation { BookNameBi = Bname, AuthorBi = AuthName, CoverImgBi = ImgCov };
        }
    }
}
