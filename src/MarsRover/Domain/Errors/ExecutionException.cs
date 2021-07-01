using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain.Errors
{
    public class ExecutionException : Exception
    {
        public ExecutionException(string message) : base(message)
        {

        }
    }
}
