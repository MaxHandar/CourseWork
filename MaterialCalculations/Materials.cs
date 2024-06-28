using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialsCalculations
{
    // Базовый абстрактный класс для всех материалов
    public class MaterialChosen
    {
        public string WallsMaterial {  get; set; }
        public string WallsUnitName {  get; set; }
        public double WallsUnitAmount { get; set; }
        public string FloorMaterial {  get; set; }
        public string FloorUnitName { get; set; }
        public double FloorUnitAmount { get; set; }
        public bool GlueNeeded = false;
        public double[] GlueAmount { get; set; }

        public MaterialChosen()
        {
            WallsMaterial = string.Empty;
            WallsUnitName = string.Empty;
            WallsUnitAmount = 0;
            FloorMaterial = string.Empty;
            FloorUnitName = string.Empty;
            GlueNeeded = false;
            GlueAmount = new double[] { 0, 0 };
            FloorUnitAmount = 0;
        }
        public MaterialChosen(bool glueNeeded, double glueBucketAmount = 0)
        {
            GlueNeeded = glueNeeded;
            GlueAmount[0] = glueBucketAmount;
            GlueAmount[1] = 0;
        }
    }

    public abstract class Material
    {
        public double Area { get; set; } // Общая площадь для покрытия

        public string UnitName { get; set; }
        // Конструктор
        public Material(double area)
        {
            Area = area;
        }

        // Абстрактный метод для расчета количества материала
        public abstract double CalculateMaterialAmount();
    }
    public class Glue: Material
    {
        public double ThicknessCoverage { get; set; }
        public double BucketVolume { get; }
        public Glue(double area, double bucketVolume, double thicknessCoverage) : base(area)// Единица измерения
        {
            UnitName = "Банка";
            BucketVolume = bucketVolume;
            ThicknessCoverage = thicknessCoverage;
        }

        // Метод для расчета количества клея в банках
        public override double CalculateMaterialAmount()
        {
            // Округляем до ближайшего целого числа, так как клей продается целыми банками
            return Math.Ceiling(Area / (BucketVolume * 1000 / ThicknessCoverage));
        }
    }

    // Класс для обоев
    public class Wallpaper : Material
    {
        public double RollCoverage { get; set; } // Площадь, которую покрывает один рулон

        public Wallpaper(double area, double rollCoverage) : base(area)
        {
            RollCoverage = rollCoverage;
            UnitName = "Рулон";
        }

        public override double CalculateMaterialAmount()
        {
            return Area / RollCoverage;
        }
    }

    // Класс для плитки
    public class Tile : Material
    {
        public double TileArea { get; set; } // Площадь одной плитки
        public Tile(double area, double tileArea) : base(area)
        {
            TileArea = tileArea;
            UnitName = "Плитка";
        }

        public override double CalculateMaterialAmount()
        {
            return Area / TileArea;
        }
    }

    // Класс для декоративной штукатурки
    // Класс для краски
    public class Paint : Material
    {
        public double CanVolume { get; set; } // Объем одной банки краски в миллилитрах
        public double CoatingThickness { get; set; } // Толщина покрытия в сантиметрах

        public Paint(double area, double canVolume, double coatingThickness) : base(area)
        {
            CanVolume = canVolume;
            CoatingThickness = coatingThickness;
            UnitName = "Банка";
    }

        public override double CalculateMaterialAmount()
        {
            // Переводим объем банки в квадратные сантиметры и делим на толщину покрытия
            return Area / (CanVolume * 1000 / CoatingThickness);
        }
    }

    // Класс для декоративной штукатурки
    public class DecorativePlaster : Material
    {
        public double BucketVolume { get; set; } // Объем одной банки штукатурки в миллилитрах
        public double CoatingThickness { get; set; } // Толщина покрытия в сантиметрах

        public DecorativePlaster(double area, double bucketVolume, double coatingThickness) : base(area)
        {
            BucketVolume = bucketVolume;
            CoatingThickness = coatingThickness;
            UnitName = "Банка";
        }

        public override double CalculateMaterialAmount()
        {
            // Переводим объем банки в квадратные сантиметры и делим на толщину покрытия
            return Area / (BucketVolume * 1000 / CoatingThickness);
        }
    }

    // Класс для ламината
    public class Laminate : Material
    {
        public double BoardArea { get; set; } // Площадь одной доски ламината

        public Laminate(double area, double boardArea) : base(area)
        {
            BoardArea = boardArea;
            UnitName = "Доска";
        }

        public override double CalculateMaterialAmount()
        {
            return Area / BoardArea;
        }
    }

    // Класс для паркета
    public class Parquet : Material
    {
        public double BoardArea { get; set; } // Площадь одной доски паркета

        public Parquet(double area, double boardArea) : base(area)
        {
            BoardArea = boardArea;
            UnitName = "Доска";
        }

        public override double CalculateMaterialAmount()
        {
            return Area / BoardArea;
        }
    }

    // Класс для линолеума
    public class Linoleum : Material
    {
        public double RollArea { get; set; }

        public Linoleum(double area, double rollArea) : base(area)
        {
            RollArea = rollArea;
            UnitName = "Рулон";
        }

        public override double CalculateMaterialAmount()
        {
            return Area / (RollArea);
        }
    }

}
