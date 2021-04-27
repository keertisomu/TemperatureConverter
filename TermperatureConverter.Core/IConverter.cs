using System;
using System.Collections.Generic;
using System.Text;

namespace TermperatureConverter.Core
{
    public interface IConverter
    {
        double ToFarenheit(string fromUnit, double tempValue);

        double ToCelsius(string fromUnit, double tempValue);

        double ToKelvin(string fromUnit, double tempValue);
    }
}
