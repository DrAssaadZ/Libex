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

namespace Libex.Tabs_userControls
{
    /// <summary>
    /// Interaction logic for addOrderUserControl.xaml
    /// </summary>
    public partial class addOrderUserControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        public addOrderUserControl()
        {
            InitializeComponent();
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmSnack.IsActive = true;
            DispatcherTimerConfirmSnack();

            Command obj = new Command(int.Parse(ClientIDBox.Text),BooksNameComboBox.Text,int.Parse( bookEditionBox.Text),bookLanguage.Text,bookAuthorBox.Text,float.Parse(bookPrice.Text));
            obj.addAnOrder();
        }

        private void DispatcherTimerConfirmSnack()
        {
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            confirmSnack.IsActive = false;
            dispatcher.Stop();
        }
    }
}
