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
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для EndedRooms.xaml
    /// </summary>
    public partial class EndedRooms : Window
    {
        public EndedRooms()
        {
            InitializeComponent();
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            NewProject mainWindow = new NewProject();
            Close();
            mainWindow.Show();
        }
    }
}
