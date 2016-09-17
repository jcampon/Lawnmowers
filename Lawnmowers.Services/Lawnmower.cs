using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmower
    {
        void ProcessAllInstructions();

        string GetFinishedInstructionsOutput();
    }

    public class Lawnmower : ILawnmower
    {
        public LawnDimensions LawnDimensionsReference { get; set; }
        public LocationCoordinates Position { get; set; }
        public char Orientation { get; set; }
        public string Instructions { get; set; }

        private const char NORTH = 'N';
        private const char WEST = 'W';
        private const char SOUTH = 'S';
        private const char EAST = 'E';
        private const char ROTATE_TO_LEFT = 'L';
        private const char ROTATE_TO_RIGHT = 'R';
        private const char MOVE = 'M';

        public void ProcessAllInstructions()
        {
            foreach (var instruction in Instructions)
            {
                Process(instruction);
            }
        }

        public string GetFinishedInstructionsOutput()
        {
            return $"{Position.LocationOnAxisX} {Position.LocationOnAxisY} {Orientation}";
        }

        #region Private Helper Methods

        private void Process(char instruction)
        {
            if (instruction == ROTATE_TO_LEFT || instruction == ROTATE_TO_RIGHT)
                RotateTowards(instruction);

            if (instruction == MOVE)
                Move();
        }

        #region methods for handling Lawnmower Orientation

        private void RotateTowards(char instructionOfRotation)
        {
            if (instructionOfRotation == ROTATE_TO_LEFT)
                Orientation = RotateToLeft();
            else if (instructionOfRotation == ROTATE_TO_RIGHT)
                Orientation = RotateToRight();
        }

        private char RotateToLeft()
        {
            var newOrientationAfterRotatingToLeft = new Dictionary<char, char>()
            {
                {NORTH, WEST},
                {WEST, SOUTH},
                {SOUTH, EAST},
                {EAST, NORTH}
            };

            return newOrientationAfterRotatingToLeft[Orientation];
        }

        private char RotateToRight()
        {
            var newOrientationAfterRotatingToRight = new Dictionary<char, char>()
            {
                {NORTH, EAST},
                {EAST, SOUTH},
                {SOUTH, WEST},
                {WEST, NORTH}
            };

            return newOrientationAfterRotatingToRight[Orientation];
        }

        #endregion

        #region methods for handling Lawnmower Movements

        private void Move()
        {
            if (LawnmowerCanMove()) // See comments below for this check
            {
                var updateLocationAfterMovingTowards = new Dictionary<char, Action>()
                {
                    {NORTH, () => UpdateLocationOnAxisY(1)},
                    {SOUTH, () => UpdateLocationOnAxisY(-1)},
                    {EAST, () => UpdateLocationOnAxisX(1)},
                    {WEST, () => UpdateLocationOnAxisX(-1)}
                };

                updateLocationAfterMovingTowards[Orientation]();
            }
        }

        private void UpdateLocationOnAxisX(int positionsToMove)
        {
            Position.LocationOnAxisX += positionsToMove;
        }

        private void UpdateLocationOnAxisY(int positionsToMove)
        {
            Position.LocationOnAxisY += positionsToMove;
        }

        /// <summary>
        /// This method WOULD handle the control to check the boundaries of the lawn and would decide on whether or not
        /// to allow a mower to advance one position according to whether the lawnmower is allowed to go BEYOND the boundaries 
        /// of the lawn and potentially thrash the surrounding gardens of rare plants
        /// </summary>
        /// <remarks>
        /// The instructions for this test, as they are redacted, DO NOT require the lawnmowers to check and control the boundaries
        /// of the lawn and do not give any specific behavior to implement in cases where the instructions given to the lawnmower 
        /// could potentially take it beyond the boundaries of the lawn (should it simply stop at the border? Maybe turn 180 degress 
        /// or simply always left or always right??)
        /// 
        /// As no such requirements are given, my implementation would simply not cater for this posibility at all, and it will take the 
        /// lawnmowers beyond the boundaries of the lawn and on a rampage across all those beautiful and rare plants... :-(
        /// 
        /// But because I love plants ;-) I have added this little method that I would use to implement this boundaries control if needed
        /// </remarks>
        private bool LawnmowerCanMove()
        {
            return true;
        }

        #endregion

        #endregion
    }
}
