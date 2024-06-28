using MaterialsCalculations;
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
using System.Windows.Shapes;
using Window = System.Windows.Window;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для RoomResults.xaml
    /// </summary>
    public partial class RoomResults : Window
    {
        RoomBase room = new RoomBase();
        MaterialChosen materials = new MaterialChosen();
        Label InfoLabel = new Label();
        public RoomResults()
        {
            InitializeComponent();
        }
        public RoomResults(RoomBase Room, MaterialChosen Materials)
        {
            InitializeComponent();
            this.room = Room;
            this.materials = Materials;

            InfoLabel.Content = $"Название команты - {room.Name}" ;
            InfoLabel.FontSize = 15;
            Info.Children.Add(InfoLabel);
            InfoLabel = new Label();
            InfoLabel.Content = $"Периметр пола - {room.FloorPerimeter}";
            InfoLabel.FontSize = 15;
            Info.Children.Add(InfoLabel);
            InfoLabel = new Label();
            InfoLabel.Content = $"Пол:\nПлощадь={room.FloorArea} Количество({materials.FloorMaterial}-{materials.FloorUnitName})={materials.FloorUnitAmount}";
            InfoLabel.FontSize = 15;
            Info.Children.Add(InfoLabel);
            InfoLabel = new Label();
            InfoLabel.Content = $"Стены:\nПлощадь={room.WallsArea} Количество({materials.WallsMaterial}-{materials.WallsUnitName})={materials.WallsUnitAmount}";
            InfoLabel.FontSize = 15;
            Info.Children.Add(InfoLabel);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProject mainWindow = new NewProject();
            Close();
            mainWindow.Show();
        }
    }
}
