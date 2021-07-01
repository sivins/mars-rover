using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class RoverStart
    {
        public string Name { get; set; }
        public int StartingX { get; set; }
        public int StartingY { get; set; }
        public char StartingZ { get; set; }
        public string Instructions { get; set; }
    }
}
