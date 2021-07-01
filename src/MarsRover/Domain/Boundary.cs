using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class Boundary
    {
        private int _maxX;
        private int _maxY;
        private int _minX;
        private int _minY;

        public Boundary(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            _maxX = maxX;
            _maxY = maxY;
            _minX = minX;
            _minY = minY;
        }

        public bool LocationIsWithinBoundary(Rover location)
        {
            return location.CurrentX >= _minX
                && location.CurrentX <= _maxX
                && location.CurrentY >= _minY
                && location.CurrentY <= _maxY;
        }
    }
}
