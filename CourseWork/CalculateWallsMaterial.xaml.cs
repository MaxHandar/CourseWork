using RoomData;
using MaterialsCalculations;
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
    /// Логика взаимодействия для TotalCalculate.xaml
    /// </summary>
    public partial class CalculateWallsMaterial : Window
    {
        MaterialChosen materials = new MaterialChosen();
        public RoomBase room;
        double UnitArea, GlueArea, VolumeDouble;
        TextBox Length = new TextBox(),
            Width = new TextBox(),
            Volume = new TextBox();
        public CalculateWallsMaterial()
        {
            InitializeComponent();
        }
        void ShowLengthWidth(string LengthLabelContent, string WidthLabelContent)
        {
            Label unitAreaLengthLabel = new Label()
            {
                Content = LengthLabelContent
            };
            WallsMaterialCalculation.Children.Add(unitAreaLengthLabel);
            WallsMaterialCalculation.Children.Add(Length);
            Label unitAreaWidthLabel = new Label()
            {
                Content = WidthLabelContent
            };
            WallsMaterialCalculation.Children.Add(unitAreaWidthLabel);
            WallsMaterialCalculation.Children.Add(Width);
        }
        void ShowVolume(string VolumeLabel)
        {
            Label unitVolumeLabel = new Label()
            {
                Content = VolumeLabel
            };
            WallsMaterialCalculation.Children.Add(unitVolumeLabel);
            WallsMaterialCalculation.Children.Add(Volume);
        }
        public CalculateWallsMaterial(RoomBase room, string WallMaterialName, string FloorMaterialName)
        {
            InitializeComponent();
            this.room = room;
            materials.WallsMaterial = WallMaterialName;
            materials.FloorMaterial = FloorMaterialName;
            if (WallMaterialName == "Обои")
            {
                ShowLengthWidth("\nРАСЧЕТ РУЛОНОВ\nДлина одного рулона:", "Ширина одного рулона:");
                ShowVolume("\nРАСЧЕТ КЛЕЯ\nОбъем банки:");
                materials.WallsUnitName = "Рулон";
            }
            if (WallMaterialName == "Плитка")
            {
                ShowLengthWidth("\nРАСЧЕТ ПЛИТОК\nДлина одной плитки:", "Ширина одной плитки:");
                ShowVolume("\nРАСЧЕТ КЛЕЯ\nОбъем банки:");
                materials.WallsUnitName = "Плитка";
            }
            if (WallMaterialName == "Краска")
            {
                ShowVolume("Объем одной банки:");
                materials.WallsUnitName = "Банка";
            }
            if (WallMaterialName == "Декоративная штукатурка")
            {
                ShowVolume("Объем одной банки:");
                materials.WallsUnitName = "Банка";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (materials.WallsMaterial)
            {
                case "Обои":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Wallpaper WallPaper = new Wallpaper(room.WallsArea, UnitArea);
                    VolumeDouble = double.Parse(Volume.Text);
                    Glue WallPaperGlue;
                    WallPaperGlue = new Glue(room.WallsArea, VolumeDouble, 0.015);

                    materials.WallsUnitAmount = WallPaper.CalculateMaterialAmount();
                    materials.GlueNeeded = true;
                    materials.GlueAmount[0] = WallPaperGlue.CalculateMaterialAmount();
                    break;

                case "Плитка":
                    UnitArea = double.Parse(Length.Text) * double.Parse(Width.Text);
                    Tile Tile = new Tile(room.WallsArea, UnitArea);
                    VolumeDouble = double.Parse(Volume.Text);
                    Glue TileGlue;
                    TileGlue = new Glue(room.WallsArea, VolumeDouble, 0.35);
                    materials.WallsUnitAmount = Tile.CalculateMaterialAmount();
                    materials.GlueNeeded = true;
                    materials.GlueAmount[0] = TileGlue.CalculateMaterialAmount();
                    break;

                case "Краска":
                    VolumeDouble = double.Parse(Volume.Text);
                    Paint Paint;
                    Paint = new Paint(room.WallsArea, VolumeDouble, 0.035);
                    materials.WallsUnitAmount = Paint.CalculateMaterialAmount();
                    break;

                case "Декоративная штукатурка":
                    VolumeDouble = double.Parse(Volume.Text);
                    DecorativePlaster Plaster;
                    Plaster = new DecorativePlaster(room.WallsArea, VolumeDouble, 0.2);
                    materials.WallsUnitAmount = Plaster.CalculateMaterialAmount();
                    break;
            }
            СalculateFloorMaterials floorMaterials = new СalculateFloorMaterials(room, materials);
            Close();
            floorMaterials.Show();
        }
    }
}
