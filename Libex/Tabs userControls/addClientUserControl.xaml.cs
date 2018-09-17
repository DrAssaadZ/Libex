using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
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
        //dispatcher vars
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer dispatcher2 = new System.Windows.Threading.DispatcherTimer();

        public addClientUserControl()
        {
            InitializeComponent();
        }

        //add client button event
        private void addClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addClientNameBox.Text.Any(char.IsDigit) || addClientFnameBox.Text.Any(char.IsDigit) ||  addClientNameBox.Text.Length < 2 || addClientFnameBox.Text.Length < 2 || addClientGenderBox.Text.Length == 0 || addClientAgeBox.Text.Length == 0 )
            {
                if (addClientNameBox.Text.Length < 2)
                {
                    hint1.Text = "Name is empty or too short";
                }
                else if (addClientNameBox.Text.Any(char.IsDigit))
                {
                    hint1.Text = "Name contains a number";
                }
                else
                {
                    hint1.Text = "";
                }
                
                if (addClientFnameBox.Text.Length < 2)
                {
                    hint2.Text = "Family name is empty or too short";
                }
                else if (addClientFnameBox.Text.Any(char.IsDigit))
                {
                    hint2.Text = "Family name contains a number";
                }
                else
                {
                    hint2.Text = "";
                }
                if (addClientGenderBox.Text.Length == 0)
                {
                    hint3.Text = "Choose a gender";
                }
                else
                {
                    hint3.Text = "";
                }
                if (addClientAgeBox.Text.Length == 0)
                {
                    hint4.Text = "Choose an age period";
                }
                else
                {
                    hint4.Text = "";
                }
            }
            else
            {
                hint1.Text = "";
                hint2.Text = "";
                hint3.Text = "";
                hint4.Text = "";

                addSnackBar.IsActive = true;
                DispatcherTimerAddClientAddSnack();

                Client obj = new Client(addClientNameBox.Text, addClientFnameBox.Text, addClientGenderBox.Text, addClientAgeBox.Text);
                obj.insertClient();
            }
           
        }

        //print button event
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
    }
}
