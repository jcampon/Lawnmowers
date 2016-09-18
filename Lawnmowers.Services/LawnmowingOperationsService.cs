﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmowingOperationsService
    {
        List<Lawnmower> Lawnmowers { get; }

        bool ValidateTheInput(string instructions);

        void MowTheLawnUsingTheInput(string instructions);

        string GetOutputResultsAfterLawnmowing();
    }

    public class LawnmowingOperationsService : ILawnmowingOperationsService
    {
        private ILawnmowingInstructionsInputValidator _inputValidator = new LawnmowingInstructionsInputValidator();
        private ILawnmowingInstructionsInputParser _inputParser = new LawnmowingInstructionsInputParser();
        private List<Lawnmower> _lawnmowers = new List<Lawnmower>();

        public List<Lawnmower> Lawnmowers
        {
            get
            {
                return _lawnmowers;
            }
        }

        public string ErrorMessageFromValidationFailure = string.Empty;


        public bool ValidateTheInput(string instructions)
        {
            return _inputValidator.Validate(instructions);
        }

        public void MowTheLawnUsingTheInput(string instructions)
        {
            if (ValidateTheInput(instructions))
            {
                ParseTheInput(instructions);
                OperateAllLawnmowersUsingTheInput(instructions);
            }
            else
                ErrorMessageFromValidationFailure = "Error! The input instructions provided are nor correct";
        }       

        public string GetOutputResultsAfterLawnmowing()
        {
            var OutputResultsAfterLawnmowing = new StringBuilder();

            foreach (var lanwmower in Lawnmowers)
            {
                OutputResultsAfterLawnmowing.Append(lanwmower.GetFinishedInstructionsOutput());
            }

            return OutputResultsAfterLawnmowing.ToString();
        }

        #region Private Helper Methods

        private void ParseTheInput(string instructions)
        {
            _lawnmowers.Clear();
            _lawnmowers.AddRange(_inputParser.GetListOfLawnMowersFrom(instructions));
        }

        private void OperateAllLawnmowersUsingTheInput(string instructions)
        {
            foreach (var lanwmower in Lawnmowers)
            {
                lanwmower.ProcessAllInstructions();
            }            
        }

        #endregion
    }
}
