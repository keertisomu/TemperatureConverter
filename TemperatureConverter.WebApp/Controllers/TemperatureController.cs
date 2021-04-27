using System;
using Microsoft.AspNetCore.Mvc;
using TermperatureConverter.Core;

namespace TemperatureConverter.WebApp.Controllers
{
    [Route("api/v1/temperatureconverter")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly IConverter _converter;

        public TemperatureController(IConverter converter)
        {
            _converter = converter;
        }

        [Route("{fromUnit}/units/{toUnit}/convert/{temperatureValue}")]
        [HttpGet]
        public IActionResult Get(string fromUnit, string toUnit, double temperatureValue)
        {
            if (!Enum.TryParse(fromUnit, out Unit fromUnitVal))
            {
                return BadRequest();
            }

            if (!Enum.TryParse(toUnit, out Unit toUnitVal))
            {
                return BadRequest();
            }

            if(fromUnitVal == toUnitVal)
            {
                return Ok(temperatureValue);
            }

            double convertedValue;
            switch (toUnitVal)
            {
                case Unit.Celsius:
                    convertedValue = _converter.ToCelsius(fromUnit, temperatureValue);
                    break;
                case Unit.Farenheit:
                    convertedValue = _converter.ToFarenheit(fromUnit, temperatureValue);
                    break;
                case Unit.Kelvin:
                    convertedValue = _converter.ToKelvin(fromUnit, temperatureValue);
                    break;
                default:
                    return BadRequest();
            }

            return Ok(convertedValue);
            
        }
    }
}
