using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assign1.Validation
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? input = value as string;
            if (string.IsNullOrWhiteSpace(input)) return ValidationResult.ValidResult;
            if (int.TryParse(input, out _))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Please enter a valid number.");
        }
    }
}
