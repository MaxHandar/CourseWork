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
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        public NewProject()
        {
            InitializeComponent();
        }
        private void Button_Click_NewRoom(object sender, RoutedEventArgs e)
        {
            NewRoom newProject = new NewRoom();
            Close();
            newProject.Show();
        }
        private void Button_Click_EndedRooms(object sender, RoutedEventArgs e)
        {
            EndedRooms endedProjects = new EndedRooms();
            Close();
            endedProjects.Show();
        }
    }
}
