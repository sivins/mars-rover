using MarsRover.Domain;
using MarsRover.Domain.Errors;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public RoverResponse DeployRovers(RoverRequest roverRequest)
        {
            List<RoverResult> results = new List<RoverResult>();

            Boundary boundary = new Boundary(roverRequest.MaxX, roverRequest.MaxY);

            foreach(var roverStart in roverRequest.Rovers)
            {
                try
                {
                    Rover rover = new Rover(roverStart.StartingX, roverStart.StartingY, roverStart.StartingZ, boundary, roverStart.Instructions);

                    rover.ExecuteInstructions();

                    results.Add(new RoverResult { Name = roverStart.Name, ResultMessage = $"Rover ended at position {rover.CurrentX} {rover.CurrentY} {rover.CurrentZ}" });
                }
                catch(ArgumentException argex)
                {
                    results.Add(new RoverResult { Name = roverStart.Name, ResultMessage = $"Invalid parameter received: {argex.Message}" });
                }
                catch(ExecutionException exEx)
                {
                    results.Add(new RoverResult { Name = roverStart.Name, ResultMessage = exEx.Message });
                }
            }

            return new RoverResponse { RoverResults = results };
        }
    }
}
