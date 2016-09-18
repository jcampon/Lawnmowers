using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public interface IValidatorConditionStrategy
    {
        bool ValidateCondition(string instructions);
    }
}
