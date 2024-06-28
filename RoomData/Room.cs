using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RoomData
{
    public class Room: RoomBase
    {
        public double Height { get; private set; }
        public int NumberOfWalls { get; private set; }
        public Wall[] Walls { get; set; }
        public int NumberOfWindows { get; private set; }
        public Window[] Windows { get; set; }
        public int NumberOfDoors { get; private set; }
        public Door[] Doors { get; set; }

        public Room() { }
        public Room(string name, double height, int numberOfWalls, int numberOfWindows, int numberOfDoors)
        {
            Name = name;
            Height = height;
            NumberOfWalls = numberOfWalls;
            NumberOfWindows = numberOfWindows;
            NumberOfDoors = numberOfDoors;
        }

        // Метод для задания стен в список
        public void SetDoors(double[] Widths, double[] Heights)
        {
            Doors = new Door[NumberOfDoors];
            bool isSameDoorsParameters = false; // если одинаковые двери - то задаем их только 1 раз
            double width = Widths[0];
            double height = Heights[0];
            Doors[0] = new Door(width, height);

            if (isSameDoorsParameters && (NumberOfDoors > 1))
            {
                for (int i = 1; i < NumberOfDoors; i++)
                {
                    Doors[i] = new Door(width, height);
                }
            }
            else
            {
                for (int i = 1; i < NumberOfDoors; i++)
                {
                    width = Widths[i];
                    height = Heights[i];
                    Doors[i] = new Door(width, height);
                }
            }
        }
        public void SetWindows(double[] Widths, double[] Heights)
        {
            Windows = new Window[NumberOfWindows];
            bool isSameWindowsParameters = false; // если одинаковые двери - то задаем их только 1 раз
            double width = Widths[0];
            double height = Heights[0];
            Windows[0] = new Window(width, height);

            if (isSameWindowsParameters && (NumberOfWindows > 1))
            {
                for (int i = 1; i < NumberOfWindows; i++)
                {
                    Windows[i] = new Window(width, height);
                }
            }
            else
            {
                for (int i = 1; i < NumberOfWindows; i++)
                {
                    width = Widths[i];
                    height = Heights[i];
                    Windows[i] = new Window(width, height);
                }
            }
        }

        public void SetWalls(double[] Widths, double[] Angles)
        {
            bool isRectangle = false; // прямоугольная комната
            Walls = new Wall[NumberOfWalls];
            double width = Widths[0];
            double angleToNextWall = Angles[0];
            double xCord = width;
            double yCord = 0;
            Point connectionPoint = new Point(xCord, yCord);

            Walls[0] = new Wall(width, angleToNextWall, connectionPoint);

            for (int i = 1; i < NumberOfWalls; i++)
            {
                width = Widths[i];
                xCord = xCord + width * Math.Cos(angleToNextWall * Math.PI / 180);
                yCord = yCord + width * Math.Sin(angleToNextWall * Math.PI / 180);
                connectionPoint = new Point(xCord, yCord);
                angleToNextWall += Angles[i];

                Walls[i] = new Wall(width, angleToNextWall, connectionPoint);
            }
        }

        public void CalculateFloorArea()
        {
            Point[] points = Walls.Select(wall => wall.ConnectionPoint)
                    .ToArray();
            double s = 0;
            int n = points.Length;
            for (int i = 0; i < points.Length; i++)
            {
                Point a = points[i];
                Point b = points[(i + 1) % n];
                s += a.X * b.Y - b.X * a.Y;
            }
            FloorArea = 0.5 * Math.Abs(s);
        }
        public void CalculateWallsArea()
        {
            WallsArea = (FloorPerimeter + Doors.Select(door => door.Width).Sum()) * Height
                        - Doors.Select(door => door.Area).Sum()
                        - Windows.Select(window => window.Area).Sum();
        }
        public void CalculateFloorPerimeter()
        {
            FloorPerimeter = Walls.Select(wall => wall.Width).Sum() -
                            Doors.Select(door => door.Width).Sum();
        }

        // Метод для проверки, добавлены ли все стены
        private bool IsRoomComplete()
        {
            foreach (var wall in Walls)
            {
                if (wall == null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Window
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Area { get; private set; }

        public Window(double width, double height)
        {
            Width = width;
            Height = height;
            Area = width * height;
        }
    }

    public class Door
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Area { get; private set; }

        public Door(double width, double height)
        {
            Width = width;
            Height = height;
            Area = width * height;
        }
    }
}
