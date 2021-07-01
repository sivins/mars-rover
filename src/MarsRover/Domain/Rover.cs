using MarsRover.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Domain
{
    public class Rover
    {
        private readonly Boundary _boundary;
        private readonly string _instructions;

        public Rover(int startingX, int startingY, char startingZ, Boundary boundary, string instructions)
        {
            if (startingZ != 'N' && startingZ != 'S' && startingZ != 'W' && startingZ != 'E')
            {
                throw new ArgumentException("Starting Z must be N, S, W, or E");
            }

            if (boundary is null)
            {
                throw new ArgumentNullException(nameof(boundary));
            }

            if (instructions is null)
            {
                throw new ArgumentNullException(nameof(instructions));
            }

            CurrentX = startingX;
            CurrentY = startingY;
            CurrentZ = startingZ;
            _boundary = boundary;
            _instructions = instructions;

            if (!_boundary.LocationIsWithinBoundary(this))
            {
                throw new OffPlateauException();
            }
        }

        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }
        public char CurrentZ { get; private set; }

        public void ExecuteInstructions()
        {
            foreach(char instruction in _instructions.ToCharArray())
            {
                ApplyInstruction(instruction);
            }
        }

        private void ApplyInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    ApplyLeftTurn();
                    break;
                case 'R':
                    ApplyRightTurn();
                    break;
                case 'M':
                    ApplyForwardMove();
                    break;
                default:
                    throw new ArgumentException($"Invalid instruction received: {instruction}. Instruction string should only include L, R, or M.");
            }
        }

        private void ApplyForwardMove()
        {
            switch(CurrentZ)
            {
                case 'N':
                    CurrentY++;
                    break;
                case 'S':
                    CurrentY--;
                    break;
                case 'W':
                    CurrentX--;
                    break;
                case 'E':
                    CurrentX++;
                    break;
                default:
                    throw new InvalidOperationException($"The object somehow obtained an invalid location heading: {CurrentZ} (Should only be N, S, E, or W).");
            }

            if (!_boundary.LocationIsWithinBoundary(this))
            {
                throw new OffPlateauException();
            }
        }

        private void ApplyRightTurn()
        {
            switch (CurrentZ)
            {
                case 'N':
                    CurrentZ = 'E';
                    return;
                case 'E':
                    CurrentZ = 'S';
                    return;
                case 'S':
                    CurrentZ = 'W';
                    return;
                case 'W':
                    CurrentZ = 'N';
                    return;
                default:
                    throw new InvalidOperationException($"The object somehow obtained an invalid location heading: {CurrentZ} (Should only be N, S, E, or W).");
            }
        }

        private void ApplyLeftTurn()
        {
            switch (CurrentZ)
            {
                case 'N':
                    CurrentZ = 'W';
                    return;
                case 'W':
                    CurrentZ = 'S';
                    return;
                case 'S':
                    CurrentZ = 'E';
                    return;
                case 'E':
                    CurrentZ = 'N';
                    return;
                default:
                    throw new InvalidOperationException($"The object somehow obtained an invalid location heading: {CurrentZ} (Should only be N, S, E, or W).");
            }
        }
    }
}
