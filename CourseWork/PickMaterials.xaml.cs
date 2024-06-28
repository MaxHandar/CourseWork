using RoomData;
using static RoomData.RoomBase;
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
using Window = System.Windows.Window;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для PickMaterials.xaml
    /// </summary>
    public partial class PickMaterials : Window
    {
        RoomBase room = new RoomBase();
        public PickMaterials(Room room)
        {
            InitializeComponent();
            Loaded += PickMaterials_Loaded;
            room.CalculateFloorPerimeter();
            room.CalculateFloorArea();
            room.CalculateWallsArea();
            this.room = room;
        }

        private void PickMaterials_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock RoomNameLabel = new TextBlock
            {
                Text = $"Название комнаты - {room.Name}"
            };
            Info.Children.Add(RoomNameLabel);
            TextBlock PerimeterLabel = new TextBlock
            {
                Text = $"Периметр комнаты - {room.FloorPerimeter}"
            };
            Info.Children.Add(PerimeterLabel);
            TextBlock FloorAreaLabel = new TextBlock
            {
                Text = $"Площадь пола - {room.FloorArea}"
            };
            Info.Children.Add(FloorAreaLabel);
            TextBlock WallsAreaLabel = new TextBlock
            {
                Text = $"Свободная площадь стен - {room.WallsArea}"
            };
            Info.Children.Add(WallsAreaLabel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalculateWallsMaterial CalculateWallsMaterial = new CalculateWallsMaterial(room, Wall.Text, Floor.Text);
            Close();
            CalculateWallsMaterial.Show();
        }
    }
}
