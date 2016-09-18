using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmowingOperationsService
    {
        bool ValidateInput(string instructions);
    }

    public class LawnmowingOperationsService : ILawnmowingOperationsService
    {
        private ILawnmowingInstructionsInputValidator _inputValidator = new LawnmowingInstructionsInputValidator();

        public bool ValidateInput(string instructions)
        {
            return _inputValidator.Validate(instructions);
        }
    }
}
