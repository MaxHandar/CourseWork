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
    /// Логика взаимодействия для FillWindow.xaml
    /// </summary>
    public partial class FillWindow : Window
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
        public FillWindow()
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
        }
        public FillWindow(Room room)
        {
            InitializeComponent();
            Loaded += WallsParameters_Loaded;
            this.room = room;
            WidthTBs = new TextBox[room.NumberOfWindows];
            HeightTBs = new TextBox[room.NumberOfWindows];
        }

        private void WallsParameters_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < room.NumberOfWindows; i++)
            {
                Label widthLabel = new Label
                {
                    Content = $"Ширина окна {i + 1}:"
                };
                ColumnWindowWidth.Children.Add(widthLabel);

                TextBox widthTB = new TextBox();
                ColumnWindowWidth.Children.Add(widthTB);
                WidthTBs[i] = widthTB;

                Label angleLabel = new Label
                {
                    Content = $"Высота окна {i + 1}:"
                };
                ColumnWindowHeights.Children.Add(angleLabel);

                TextBox angleTB = new TextBox();
                ColumnWindowHeights.Children.Add(angleTB);
                HeightTBs[i] = angleTB;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room.SetWindows(FromTextBlockToDouble(WidthTBs), FromTextBlockToDouble(HeightTBs));
            FillDoor door = new FillDoor(room);
            Close();
            door.Show();
        }
    }
}
