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
    /// Логика взаимодействия для СalculateFloorMaterials.xaml
    /// </summary>
    public partial class СalculateFloorMaterials : Window
    {
        MaterialChosen materials = new MaterialChosen();
        public RoomBase room;
        double UnitArea, VolumeDouble;
        TextBox Length = new TextBox(),
            Width = new TextBox(),
            Volume = new TextBox();
        public СalculateFloorMaterials()
        {
            InitializeComponent();
        }
        void ShowLengthWidth(string LengthLabelContent, string WidthLabelContent)
        {
            Label unitAreaLengthLabel = new Label()
            {
                Content = LengthLabelContent
            };
            FloorMaterialCalculation.Children.Add(unitAreaLengthLabel);
            FloorMaterialCalculation.Children.Add(Length);
            Label unitAreaWidthLabel = new Label()
            {
                Content = WidthLabelContent
            };
            FloorMaterialCalculation.Children.Add(unitAreaWidthLabel);
            FloorMaterialCalculation.Children.Add(Width);
        }
        void ShowVolume(string VolumeLabel)
        {
            Label unitVolumeLabel = new Label()
            {
                Content = VolumeLabel
            };
            FloorMaterialCalculation.Children.Add(unitVolumeLabel);
            FloorMaterialCalculation.Children.Add(Volume);
        }
        public СalculateFloorMaterials(RoomBase room, MaterialChosen materials)
        {
            InitializeComponent();
            this.room = room;
            this.materials = materials;
            if (materials.FloorMaterial == "Линолеум")
            {
                ShowLengthWidth("\nРАСЧЕТ РУЛОНОВ\nДлина одного рулона:", "Ширина одного рулона:");
                materials.FloorUnitName = "Рулон";
            }
            if (materials.FloorMaterial == "Плитка")
            {
                ShowLengthWidth("\nРАСЧЕТ ПЛИТОК\nДлина одной плитки:", "Ширина одной плитки:");
                ShowVolume("\nРАСЧЕТ КЛЕЯ\nОбъем банки:");
                materials.FloorUnitName = "Плитка";
            }
            if (materials.FloorMaterial == "Паркет")
            {
                ShowLengthWidth("\nРАСЧЕТ Досок\nДлина одной доски:", "Ширина одной доски:");
                materials.FloorUnitName = "Доска";
            }
            if (materials.FloorMaterial == "Ламинат")
            {
                ShowLengthWidth("\nРАСЧЕТ Досок\nДлина одной доски:", "Ширина одной доски:");
                materials.FloorUnitName = "Доска";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (materials.FloorMaterial)
            {
                case "Линолеум":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Linoleum Linoleum = new Linoleum(room.FloorArea, UnitArea);
                    materials.FloorUnitAmount = Linoleum.CalculateMaterialAmount();
                    break;

                case "Плитка":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Tile Tile = new Tile(room.FloorArea, UnitArea);
                    VolumeDouble = double.Parse(Volume.Text);
                    Glue TileGlue;
                    TileGlue = new Glue(room.FloorArea, VolumeDouble, 0.35);
                    materials.FloorUnitAmount = Tile.CalculateMaterialAmount();
                    materials.GlueNeeded = true;
                    materials.GlueAmount[1] = TileGlue.CalculateMaterialAmount();
                    break;

                case "Паркет":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Parquet Parquet = new Parquet(room.FloorArea, UnitArea);
                    materials.FloorUnitAmount = Parquet.CalculateMaterialAmount();
                    break;

                case "Ламинат":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Laminate laminate = new Laminate(room.FloorArea, UnitArea);
                    materials.FloorUnitAmount = laminate.CalculateMaterialAmount();
                    break;
                
            }
            RoomResults results = new RoomResults(room, materials);
            Close();
            results.Show();
        }
    }
}
