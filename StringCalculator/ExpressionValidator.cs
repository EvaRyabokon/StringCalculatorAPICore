using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringCalculator
{

    public struct ValidationResult 
    {
        private ValidationResult(bool isSuccessful, string error)
        {
            Error = error;
            IsSuccessful = isSuccessful;
        }

        public string Error { get; }
        public bool IsSuccessful { get; }

        public static ValidationResult Successful()
        {
            return new ValidationResult(true, null);
        }       
        
        public static ValidationResult Unsuccessful(string error)
        {
            return new ValidationResult(false, error);
        }
    }

    public class ExpressionValidator
    {
        private const string StringIsEmptyError = "Empty String";
        private const string InvalidFormatError = "Invalid Format";

        public ValidationResult Validate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return ValidationResult.Unsuccessful(StringIsEmptyError);
            }
            
            var splittedExpresion = expression.Split(Calculator.AvailableOperations);

            int i = 0;
            foreach (var item in splittedExpresion)
            {
                if (!int.TryParse(item, out i))
                {
                    return ValidationResult.Unsuccessful(InvalidFormatError);
                }
            }

            return ValidationResult.Successful();
        }
    }
}
