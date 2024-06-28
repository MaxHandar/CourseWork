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
    /// Логика взаимодействия для FillDoor.xaml
    /// </summary>
    public partial class FillDoor : Window
    {
        public Room room;
        public TextBox[] WidthTBs;
        public TextBox[] HeightTBs;

        double[] FromTextBlockToDouble(TextBox[] TB)
        {
            double[] doubles = new double[TB.Length];
            for (int i = 0; i < TB.Length; i++)
            {
                doubles[i] = double.Parse(TB[i].Text);
            }
            return doubles;
        }
        public FillDoor()
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
        }
        public FillDoor(Room room)
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
            this.room = room;
            WidthTBs = new TextBox[room.NumberOfDoors];
            HeightTBs = new TextBox[room.NumberOfDoors];
        }

        private void WallsParameters_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < room.NumberOfDoors; i++)
            {
                Label widthLabel = new Label
                {
                    Content = $"Ширина двери {i + 1}:"
                };
                ColumnDoorWidth.Children.Add(widthLabel);

                TextBox widthTB = new TextBox();
                ColumnDoorWidth.Children.Add(widthTB);
                WidthTBs[i] = widthTB;

                Label angleLabel = new Label
                {
                    Content = $"Высота двери {i + 1}:"
                };
                ColumnDoorHeights.Children.Add(angleLabel);

                TextBox angleTB = new TextBox();
                ColumnDoorHeights.Children.Add(angleTB);
                HeightTBs[i] = angleTB;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room.SetDoors(FromTextBlockToDouble(WidthTBs), FromTextBlockToDouble(HeightTBs));
            PickMaterials pickMaterials = new PickMaterials(room);
            Close();
            pickMaterials.Show();
        }
    }
}
