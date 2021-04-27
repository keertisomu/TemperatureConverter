using System;
using TermperatureConverter.Core;
using Xunit;

namespace TemperatureConverter.UnitTests
{
    public class ConverterTests
    {
        private readonly IConverter _converter;

        public ConverterTests()
        {
            _converter = new Converter();
        }

        [Fact]
        public void Convert_FromCelsius_ToFarenheit_ExpectCorrectValue()
        {
            string fromUnit = "Celsius";
            float valueToConvert = 25;

            var result = _converter.ToFarenheit(fromUnit, valueToConvert);
            Assert.Equal(77, result);
        }

        [Fact]
        public void Convert_FromCelsius_ToKelvin_ExpectCorrectValue()
        {
            string fromUnit = "Celsius";
            float valueToConvert = 25;

            var result = _converter.ToKelvin(fromUnit, valueToConvert);
            Assert.Equal(298.15, result);
        }

        [Fact]
        public void Convert_FromFarenheit_ToCelsius_ExpectCorrectValue()
        {
            string fromUnit = "Farenheit";
            float valueToConvert = 25;

            var result = _converter.ToCelsius(fromUnit, valueToConvert);
            Assert.Equal(-3.89, result);
        }

        [Fact]
        public void Convert_FromFarenheit_ToKelvin_ExpectCorrectValue()
        {
            string fromUnit = "Farenheit";
            float valueToConvert = 25;

            var result = _converter.ToKelvin(fromUnit, valueToConvert);
            Assert.Equal(269.26, result);
        }

        [Fact]
        public void Convert_FromKelvin_ToCelsius_ExpectCorrectValue()
        {
            string fromUnit = "Kelvin";
            float valueToConvert = 25;

            var result = _converter.ToCelsius(fromUnit, valueToConvert);
            Assert.Equal(-248.15, result);
        }

        [Fact]
        public void Convert_FromKelvin_ToFarenheit_ExpectCorrectValue()
        {
            string fromUnit = "Kelvin";
            float valueToConvert = 25;

            var result = _converter.ToFarenheit(fromUnit, valueToConvert);
            Assert.Equal(-414.67, result);
        }
    }
}
