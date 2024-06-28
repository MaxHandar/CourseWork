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
    /// Логика взаимодействия для FillWall.xaml
    /// </summary>
    public partial class FillWall : Window
    {
        public Room room;
        public TextBox[] WidthTBs;
        public TextBox[] AnglesTBs;

        double[] FromTextBlockToDouble(TextBox[] TB)
        {
            double[] doubles = new double[TB.Length];
            for (int i = 0; i < TB.Length; i++)
            {
                doubles[i] = double.Parse(TB[i].Text);
            }
            return doubles;
        }
        public FillWall()
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
        }
        public FillWall(Room room)
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
            this.room = room;
            WidthTBs = new TextBox[room.NumberOfWalls];
            AnglesTBs = new TextBox[room.NumberOfWalls];
        }

        private void WallsParameters_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < room.NumberOfWalls; i++)
            {
                Label widthLabel = new Label
                {
                    Content = $"Ширина стены {i + 1}:"
                };
                ColumnWallWidth.Children.Add(widthLabel);

                TextBox widthTB = new TextBox();
                ColumnWallWidth.Children.Add(widthTB);
                WidthTBs[i] = widthTB;

                Label angleLabel = new Label
                {
                    Content = $"Угол между стенами {i + 1} и {(i + 1) % room.NumberOfWalls + 1}:"
                };
                ColumnWallAngles.Children.Add(angleLabel);

                TextBox angleTB = new TextBox();
                ColumnWallAngles.Children.Add(angleTB);
                AnglesTBs[i] = angleTB;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room.SetWalls(FromTextBlockToDouble(WidthTBs), FromTextBlockToDouble(AnglesTBs));
            FillWindow window = new FillWindow(room);
            Close();
            window.Show();
        }
    }
}
