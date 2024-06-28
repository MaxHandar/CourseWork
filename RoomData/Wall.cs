using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomData
{
    public class Wall
    {
        public double Width { get; private set; }
        public double AngleToNextWall { get; private set; }
        public Point ConnectionPoint { get; private set; }

        public Wall(double width, double angleToNextWall, Point connectionPoint)
        {
            Width = width;
            AngleToNextWall = angleToNextWall;
            ConnectionPoint = connectionPoint;
        }
    }
}
