using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomData
{
    public class RoomBase
    {
        public string Name { get; set; }
        public double FloorPerimeter { get; set; }
        public double FloorArea { get; set; }
        public double WallsArea { get; set; }

        public RoomBase() { }

        public RoomBase(string name, double floorPerimeter, double floorArea, double wallsArea)
        {
            Name = name;
            FloorPerimeter = floorPerimeter;
            FloorArea = floorArea;
            WallsArea = wallsArea;
        }
    }
}
