﻿using System;
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
    /// Interaction logic for addSBookUserControl.xaml
    /// </summary>
    public partial class addSBookUserControl : UserControl
    {
        System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
        public addSBookUserControl()
        {
            InitializeComponent();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmSnack.IsActive = true;
            DispatcherTimerConfirmSnack();
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
