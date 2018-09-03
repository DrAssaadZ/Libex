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
    /// Interaction logic for addClientUserControl.xaml
    /// </summary>
    public partial class addClientUserControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer dispatcher2 = new System.Windows.Threading.DispatcherTimer();
        public addClientUserControl()
        {
            InitializeComponent();
        }

        private void addClientBtn_Click(object sender, RoutedEventArgs e)
        {
            addSnackBar.IsActive = true;
            DispatcherTimerAddClientAddSnack();
        }

        private void DispatcherTimerprintSnack()
        {
            dispatcher2.Tick += new EventHandler(dispatcherTimer2_Tick);
            dispatcher2.Interval = new TimeSpan(0, 0, 2);
            dispatcher2.Start();
        }

        private void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
            printSnackBar.IsActive = false;
            dispatcher2.Stop();
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            printSnackBar.IsActive = true;
            DispatcherTimerprintSnack();
        }

        //timer that closes the addsnackbar
        private void DispatcherTimerAddClientAddSnack()
        {
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 2);
            dispatcher.Start();

        }

        //stop the timer after 2 secs
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            addSnackBar.IsActive = false;
            dispatcher.Stop();
        }

    }
}
