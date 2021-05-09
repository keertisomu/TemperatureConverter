using System;
using Microsoft.AspNetCore.Mvc;
using TermperatureConverter.Core;

namespace TemperatureConverter.WebApp.Controllers
{
    [Route("api/v1/temperatureconverter")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly IUnitConverter<Temperature, float> _converter;

        public TemperatureController(IUnitConverter<Temperature, float> converter)
        {
            _converter = converter;
        }

        [Route("{fromUnit}/units/{toUnit}/convert/{temperatureValue}")]
        [HttpGet]
        public IActionResult Get(string fromUnit, string toUnit, float temperatureValue)
        {
            // check fromUnit/toUnits are valid
            if (!Enum.TryParse(fromUnit, out Temperature fromUnitVal))
            {
                return BadRequest();
            }

            if (!Enum.TryParse(toUnit, out Temperature toUnitVal))
            {
                return BadRequest();
            }

            // check if both from and to unit are same , if yes just send back the value to convert.
            // ideally should be handled at client side
            if (fromUnitVal == toUnitVal)
            {
                return Ok(temperatureValue);
            }

            //check which value to convert and call converter
            var convertedValue = _converter.Convert(temperatureValue, fromUnitVal, toUnitVal);
            return Ok(convertedValue);

        }
    }
}
