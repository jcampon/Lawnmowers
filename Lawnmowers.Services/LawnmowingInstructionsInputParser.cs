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

    }
}
