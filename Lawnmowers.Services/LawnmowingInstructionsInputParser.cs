using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmowingInstructionsInputParser
    {
        LawnDimensions GetLawnDimensionsFrom(string instructions);

        List<Lawnmower> GetListOfLawnMowersFrom(string instructions);
    }

    public class LawnmowingInstructionsInputParser : ILawnmowingInstructionsInputParser
    {        
        public LawnDimensions GetLawnDimensionsFrom(string instructions)
        {
            var topRightCornerLocationCoordinates = GetLocationCoordinatesFrom(instructions);

            return new LawnDimensions(topRightCornerLocationCoordinates);
        }

        public List<Lawnmower> GetListOfLawnMowersFrom(string instructions)
        {
            var listOfLawnmowers = new List<Lawnmower>();

            var linesOfInput = instructions.Split('\n');
            var lawnDimensionsReference = GetLawnDimensionsFrom(instructions);

            for (var i = 1; i <= linesOfInput.Count() - 1; i += 2)
            {
                var newLawnmower = GetNewLawnmowerUsing(linesOfInput[i], linesOfInput[i + 1], lawnDimensionsReference);
                listOfLawnmowers.Add(newLawnmower);
            }

            return listOfLawnmowers;
        }

        #region Private helper methods

        private Lawnmower GetNewLawnmowerUsing(string location, string instructions, LawnDimensions lawnDimensionsReference)
        {
            var lawnmower = new Lawnmower()
            {
                LawnDimensionsReference = lawnDimensionsReference,
                Instructions = instructions,
                Position = GetLocationCoordinatesFrom(location),
                Orientation = GetOrientationFrom(location)
            };

            return lawnmower;
        }

        private LocationCoordinates GetLocationCoordinatesFrom(string instructions)
        {
            var firstLineComponents = instructions.Split('\n').First().Split(' ');

            var valueForAxisX = int.Parse(firstLineComponents[0]);
            var valueForAxisY = int.Parse(firstLineComponents[1]);

            return new LocationCoordinates(valueForAxisX, valueForAxisY);
        }

        private char GetOrientationFrom(string location)
        {
            var locationComponents = location.Split(' ');

            return locationComponents[2].ToCharArray().FirstOrDefault();
        }

        #endregion
    }
}
