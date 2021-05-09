using System;
using System.Collections.Generic;
using System.Text;

namespace TermperatureConverter.Core
{
    public class UnitConverter<TUnitType, TValueType> : IUnitConverter<TUnitType, TValueType>
    {
        public TUnitType BaseUnit { get; set; }

        public IDictionary<TUnitType, Func<TValueType, TValueType>> ConvertTo = new Dictionary<TUnitType, Func<TValueType, TValueType>>();
        public IDictionary<TUnitType, Func<TValueType, TValueType>> ConvertFrom = new Dictionary<TUnitType, Func<TValueType, TValueType>>();

        public void RegisterConversion(TUnitType unitType, Func<TValueType, TValueType> conversionFrom, Func<TValueType, TValueType> conversionTo)
        {
            if (!ConvertFrom.ContainsKey(unitType))
            {
                ConvertFrom.Add(unitType, conversionFrom);
            }

            if (!ConvertTo.ContainsKey(unitType))
            {
                ConvertTo.Add(unitType, conversionTo);
            }
        }

        public TValueType Convert(TValueType value, TUnitType fromUnit, TUnitType toUnitType)
        {
            // return same value if from and to are same
            if (fromUnit.Equals(toUnitType))
            {
                return value;
            }

            // check if base unit is available
            // if base unit is available , convert value to baseunit
            TValueType valueInBaseUnit = default;
            if (BaseUnit != null)
            {
                valueInBaseUnit = fromUnit.Equals(BaseUnit) ? value : ConvertFrom[fromUnit](value);
            }
            

            // next convert "to" actual unit , using the above value.
            TValueType valueInToUnitType;
            valueInToUnitType = BaseUnit != null ? ConvertTo[toUnitType](valueInBaseUnit) : ConvertTo[toUnitType](value);

            // return the value.
            return valueInToUnitType;

        }
    }
}
