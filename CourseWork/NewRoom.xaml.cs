using RoomData;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Window = System.Windows.Window;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для NewRoom.xaml
    /// </summary>
    public partial class NewRoom : Window
    {
        public Room room = new Room();
        public NewRoom()
        {
            InitializeComponent();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
            {
            string NameOfRoom = Name.Text;
            string numOfWalls = NumOfWalls.Text;
            string height = Height.Text;
            string numOfWindows = NumOfWindows.Text;
            string numOfDoors = NumOfDoors.Text;

            if (NameOfRoom.Length < 1) 
            {
            Name.ToolTip = "Введите название комнаты";
            Name.Background = Brushes.DarkRed;
            }
            else if (numOfWalls == "")
            {
                NumOfWalls.ToolTip = "Введите количество стен";
                NumOfWalls.Background = Brushes.DarkRed;
            }
            else if (height == "")
            {
                Height.ToolTip = "Введите высоту комнаты";
                Height.Background = Brushes.DarkRed;
            }
            else if (numOfWindows == "")
            {
                NumOfWindows.ToolTip = "Введите количество окон";
                NumOfWindows.Background = Brushes.DarkRed;
            }
            else if (numOfDoors == "")
            {
                NumOfDoors.ToolTip = "Введите количество дверей";
                NumOfDoors.Background = Brushes.DarkRed;
            }
            else
            {
                double resultOfheight = double.Parse(Height.Text);
                int resultOfnumOfWalls = int.Parse(NumOfWalls.Text);
                int resultOfnumOfWindows = int.Parse(NumOfWindows.Text);
                int resultOfnumOfDoors = int.Parse(NumOfDoors.Text);

                Room room = new Room(NameOfRoom, resultOfheight, resultOfnumOfWalls, resultOfnumOfWindows, resultOfnumOfDoors);

                FillWall walls = new FillWall(room);
                Close();
                walls.Show();
            }
        }
    }
}
