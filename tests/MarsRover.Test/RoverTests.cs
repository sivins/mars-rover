using MarsRover.Domain;
using MarsRover.Domain.Errors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Test
{
    public class RoverTests
    {
        [Test]
        public void Constructor_ValidData_ShouldNotRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = "M";

            Assert.DoesNotThrow(() => _ = new Rover(startingX, startingY, startingZ, boundary, instructions));
        }

        // Obviously not an exhaustive list of all invalid chars
        [TestCase('A')]
        [TestCase('B')]
        [TestCase('C')]
        [TestCase('D')]
        [TestCase('F')]
        [TestCase('G')]
        [TestCase('H')]
        [TestCase('I')]
        [TestCase('J')]
        [TestCase('K')]
        public void Constructor_InvalidStartingZValue_ShouldRaiseError(char invalidStartingZ)
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = invalidStartingZ;
            Boundary boundary = new Boundary(5, 5);
            string instructions = "M";

            Assert.Throws<ArgumentException>(() => _ = new Rover(startingX, startingY, startingZ, boundary, instructions));
        }

        [Test]
        public void Constructor_BoundaryIsNull_ShouldRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = null;
            string instructions = "M";

            Assert.Throws<ArgumentNullException>(() => _ = new Rover(startingX, startingY, startingZ, boundary, instructions));
        }

        [Test]
        public void Constructor_InstructionsIsNull_ShouldRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = null;

            Assert.Throws<ArgumentNullException>(() => _ = new Rover(startingX, startingY, startingZ, boundary, instructions));
        }

        [Test]
        public void Constructor_StartingLocationIsOutOfBounds_ShouldRaiseError()
        {
            int startingX = -1;
            int startingY = -1;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = "LRM";

            Assert.Throws<OffPlateauException>(() => _ = new Rover(startingX, startingY, startingZ, boundary, instructions));
        }

        [Test]
        public void Execute_InvalidInstructions_ShouldRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = "bad instructions";

            Rover rover = new Rover(startingX, startingY, startingZ, boundary, instructions);

            Assert.Throws<ArgumentException>(() => rover.ExecuteInstructions());
        }

        [Test]
        public void Execute_ValidInstructions_ShouldNotRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = "LRM";

            Rover rover = new Rover(startingX, startingY, startingZ, boundary, instructions);

            Assert.DoesNotThrow(() => rover.ExecuteInstructions());
        }


        [Test]
        public void Execute_SentOutOfBounds_ShouldRaiseError()
        {
            int startingX = 0;
            int startingY = 0;
            char startingZ = 'N';
            Boundary boundary = new Boundary(5, 5);
            string instructions = "LM";

            Rover rover = new Rover(startingX, startingY, startingZ, boundary, instructions);

            Assert.Throws<OffPlateauException>(() => rover.ExecuteInstructions());
        }

        [TestCase(0, 0, 'N', 5, 5, "LRM", 0, 1, 'N')]
        [TestCase(1, 2, 'N', 5, 5, "LMLMLMLMM", 1, 3, 'N')]
        [TestCase(3, 3, 'E', 5, 5, "MMRMMRMRRM", 5, 1, 'E')]
        public void Execute_ValidInstructions_ShouldCorrectlyExecuteInstructions(
            int startingX,
            int startingY,
            char startingZ,
            int maxX,
            int maxY,
            string instructions,
            int expectedX,
            int expectedY,
            char expectedZ)
        {
            Boundary boundary = new Boundary(maxX, maxY);

            Rover rover = new Rover(startingX, startingY, startingZ, boundary, instructions);
            rover.ExecuteInstructions();

            Assert.AreEqual(expectedX, rover.CurrentX);
            Assert.AreEqual(expectedY, rover.CurrentY);
            Assert.AreEqual(expectedZ, rover.CurrentZ);
        }
    }
}
