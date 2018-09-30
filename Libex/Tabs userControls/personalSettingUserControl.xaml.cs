using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace Libex
{
    /// <summary>
    /// Interaction logic for personalSettingUserControl.xaml
    /// </summary>
    public partial class personalSettingUserControl : UserControl
    {
        public personalSettingUserControl()
        {
            InitializeComponent();
        }

        //logo button click event , browsing for images
        private void LogoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select a Logo";
                dialog.Filter = "Image files (*.png;*.jpeg,*.jpg)|*.png;*.jpeg;*.jpg";
                if (dialog.ShowDialog() == true)
                {
                    //image source                                      
                    logoContainer.Source = new BitmapImage(new Uri(dialog.FileName));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please pick an image file");
            }
        }

        //confirm button click event
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(GlobalVariables.logoPath + @"\logo.png"))
            {
                File.Delete(GlobalVariables.logoPath + @"\logo.png");
            }
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)logoContainer.Source));
            using (FileStream stream = new FileStream(GlobalVariables.logoPath + @"\logo.png", FileMode.Create))
            encoder.Save(stream);

            XmlDocument doc = new XmlDocument();
            doc.Load(SplashWindow.settingDirectoryPath + @"\Settings.xml");
            XmlNode nameNode = doc.SelectSingleNode("//LibraryName");
            nameNode.InnerText = NameBox.Text;
            XmlNode AddressNode = doc.SelectSingleNode("//Address");
            AddressNode.InnerText = AddressBox.Text;
            XmlNode ownerNode = doc.SelectSingleNode("//Owner");
            ownerNode.InnerText = OwnerBox.Text;
            XmlNode mailNode = doc.SelectSingleNode("//Email");
            mailNode.InnerText = EmailBox.Text;
            XmlNode phoneNode = doc.SelectSingleNode("//Phone");
            phoneNode.InnerText = NumberBox.Text;
            XmlNode logoNode = doc.SelectSingleNode("//Logo");
            logoNode.InnerText = "1";
            doc.Save(SplashWindow.settingDirectoryPath + @"\Settings.xml");
        }
    }
}
