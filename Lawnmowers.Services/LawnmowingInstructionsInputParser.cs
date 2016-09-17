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
            var firstLineComponents = instructions.Split('\n').First().Split(' ');

            var dimensionOfAxisX = int.Parse(firstLineComponents[0]);
            var dimensionOfAxisY = int.Parse(firstLineComponents[1]);

            return new LawnDimensions(dimensionOfAxisX, dimensionOfAxisY);
        }

        public List<Lawnmower> GetListOfLawnMowersFrom(string instructions)
        {
            var listOfLawnmowers = new List<Lawnmower>();

            var linesOfInput = instructions.Split('\n');
            for (var i = 1; i <= linesOfInput.Count() - 1; i += 2)
            {
                listOfLawnmowers.Add(new Lawnmower());
            }

            return listOfLawnmowers;
        }
    }
}
