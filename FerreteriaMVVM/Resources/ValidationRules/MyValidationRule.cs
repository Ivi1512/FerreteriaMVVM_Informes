using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FerreteriaMVVM.Resources.ValidationRules
{
    public class MyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                DateTime fechaSeleccionada = (DateTime)value;
                if(fechaSeleccionada > DateTime.Now)
                {
                    return new ValidationResult(false, "La fecha no puede ser superior a hoy");
                }
            }
            else
            {
                return new ValidationResult(false, "Introduce una fecha");
            }

            return new ValidationResult(true, null);
        }
    }
}
