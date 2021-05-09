using System;
using System.Collections.Generic;
using System.Text;

namespace TermperatureConverter.Core
{
    public interface IUnitConverter<TUnitType, TValueType>
    {

        TUnitType BaseUnit { get; set; }

        void RegisterConversion(TUnitType unitType, Func<TValueType, TValueType> conversionFrom, Func<TValueType, TValueType> conversionTo);

        TValueType Convert(TValueType value, TUnitType fromUnit, TUnitType toUnitType);

    }
}
