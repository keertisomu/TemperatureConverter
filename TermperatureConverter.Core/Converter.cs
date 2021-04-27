using System;

namespace TermperatureConverter.Core
{
    public class Converter : IConverter
    {
        public double ToFarenheit(string fromUnit, double temperatureValue)
        {
            double celsiusConverter(double tempValue)
            {
                return Math.Round((temperatureValue * 9 / 5) + 32, 2);
            }

            if(!Enum.TryParse(fromUnit, out Unit unitVal))
            {
                throw new InvalidOperationException($"Conversion to unit not available: {fromUnit}");
            }
            switch (unitVal)
            {
                case Unit.Celsius:
                    return celsiusConverter(temperatureValue);
                case Unit.Kelvin:
                    return Math.Round((temperatureValue - 273.15F) * 9 / 5  + 32, 2);
                default:
                    return celsiusConverter(temperatureValue);
            }
        }

        public double ToCelsius(string fromUnit, double temperatureValue)
        {
            double farenheitConverter(double tempValue)
            {
                return Math.Round((temperatureValue - 32) * 5 / 9, 2);
            }

            if (!Enum.TryParse(fromUnit, out Unit unitVal))
            {
                throw new InvalidOperationException($"Conversion to unit not available: {fromUnit}");
            }
            switch (unitVal)
            {
                case Unit.Farenheit:
                    return farenheitConverter(temperatureValue);
                case Unit.Kelvin:
                    return Math.Round(temperatureValue - 273.15F, 2);
                default:
                    return farenheitConverter(temperatureValue);
            }
        }

        public double ToKelvin(string fromUnit, double temperatureValue)
        {
            double kelvinConverter(double tempValue)
            {
                return Math.Round((temperatureValue - 32) * 5 / 9 + 273.15F, 2);
            }

            if (!Enum.TryParse(fromUnit, out Unit unitVal))
            {
                throw new InvalidOperationException($"Conversion to unit not available: {fromUnit}");
            }
            switch (unitVal)
            {
                case Unit.Farenheit:
                    return kelvinConverter(temperatureValue);
                case Unit.Celsius:
                    return Math.Round(temperatureValue + 273.15F, 2);
                default:
                    return kelvinConverter(temperatureValue);
            }
        }
    }
}
