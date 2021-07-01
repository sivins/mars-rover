using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain.Errors
{
    public class OffPlateauException : Exception
    {
        public static readonly string OFF_PLATEAU_MESSAGE = "Rover fell off the plateau!";

        public OffPlateauException() : base(OFF_PLATEAU_MESSAGE)
        {

        }
    }
}
