using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmowingInstructionsInputValidator
    {
        bool Validate(string instructions);
    }
}
