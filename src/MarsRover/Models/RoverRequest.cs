using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class RoverRequest
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<RoverStart> Rovers { get; set; }
    }
}
