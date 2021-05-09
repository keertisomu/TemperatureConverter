using System;
using System.Collections.Generic;
using System.Text;
using TermperatureConverter.Core;
using Xunit;

namespace TemperatureConverter.UnitTests
{
    public class GenericConverterTests
    {
        private IUnitConverter<Temperature, float> _tempConverter;

        public GenericConverterTests()
        {
            _tempConverter = new UnitConverter<Temperature, float>
            {
                BaseUnit = Temperature.Celsius
            };
            _tempConverter.RegisterConversion(Temperature.Farenheit, v => (v - 32) * 5 / 9, v => (v * 9 / 5) + 32);
            _tempConverter.RegisterConversion(Temperature.Kelvin, v => v - 273.15f, v => (v + 273.15f));
            // _converter = new Converter();
        }

        [Fact]
        public void Convert_FromCelsius_ToFarenheit_ExpectCorrectValue()
        {
            // arrange
            // act
            var convertedVal = _tempConverter.Convert(1, Temperature.Celsius, Temperature.Farenheit);
            Assert.Equal(33.8F, convertedVal);
            
        }
    }
}
