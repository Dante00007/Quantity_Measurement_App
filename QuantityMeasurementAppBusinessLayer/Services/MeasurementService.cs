using QuantityMeasurementAppModelLayer.Core;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.Units;
using QuantityMeasurementAppRepoLayer;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementHistoryRepository _repository;

        public MeasurementService()
        {
            _repository = new MeasurementHistoryRepository();
        }
        public QuantityDTO PerformConversion(QuantityDTO q, string toUnit) 
        {
            Type unitType = GetUnitFromIndex(q.EnumIndex);
            Enum unit = (Enum)Enum.Parse(unitType, q.Unit);
            Enum targetUnit = (Enum)Enum.Parse(unitType, toUnit);
            Quantity quantity = new Quantity(q.Value, unit);

            QuantityDTO res = quantity.ConvertTo(targetUnit);
            AddToHistory(q, null, res, "Conversion");

            return res;
        }

        public QuantityDTO PerformAddition(QuantityDTO q1, QuantityDTO q2, string toUnit)
        {
            Type unitType = GetUnitFromIndex(q1.EnumIndex);
            Enum unit1 =(Enum) Enum.Parse(unitType, q1.Unit);
            Enum unit2 =(Enum) Enum.Parse(unitType, q2.Unit);
            Enum targetUnit = (Enum)Enum.Parse(unitType, toUnit);

            Quantity quantity1 = new Quantity(q1.Value, unit1);
            Quantity quantity2 = new Quantity(q2.Value, unit2);
            QuantityDTO result = quantity1.Add(quantity2, targetUnit);
            AddToHistory(q1, q2, result, "Addition");
            return result;
        }

        public QuantityDTO PerformSubtraction(QuantityDTO q1, QuantityDTO q2, string toUnit)
        {
            Type unitType = GetUnitFromIndex(q1.EnumIndex);
            Enum unit1 = (Enum)Enum.Parse(unitType, q1.Unit);
            Enum unit2 = (Enum)Enum.Parse(unitType, q2.Unit);
            Enum targetUnit = (Enum)Enum.Parse(unitType, toUnit);

            Quantity quantity1 = new Quantity(q1.Value, unit1);
            Quantity quantity2 = new Quantity(q2.Value, unit2);

            QuantityDTO result = quantity1.Subtract(quantity2, targetUnit);

            AddToHistory(q1, q2, result, "Subtraction");
            return result;
        }

        public bool CheckEquality(QuantityDTO q1, QuantityDTO q2)
        {
            Type unitType = GetUnitFromIndex(q1.EnumIndex);
            Enum unit1 = (Enum)Enum.Parse(unitType, q1.Unit);
            Enum unit2 = (Enum)Enum.Parse(unitType, q2.Unit);
            double val1 = q1.Value;
            double val2 = q2.Value;
            var quantity1 = new Quantity(val1, unit1);
            var quantity2 = new Quantity(val2, unit2);

            return quantity1.Equals(quantity2);
        }

        private void AddToHistory(QuantityDTO q1, QuantityDTO? q2, QuantityDTO result,string operation)
        {
            QuantityMeasurementHistoryEntity history = new QuantityMeasurementHistoryEntity();

            history.InputValue1 = q1.Value;
            history.InputUnit1 = q1.Unit;
            history.InputValue2 = q2 == null ? 0 : q2.Value;
            history.InputUnit2 = q2 == null ? "" : q2.Unit;
            history.TargetUnit = result.Unit;
            history.Operation = operation;
            history.ResultValue = result.Value;
            history.ResultUnit = result.Unit;;
    
            _repository.SaveHistory(history);
        }
        private Type GetUnitFromIndex(int index)
        {
            return index switch
            {
                1 => typeof(LengthUnit),
                2 => typeof(WeightUnit),
                3 => typeof(VolumeUnit),
                4 => typeof(TemperatureUnit),
                _ => null
            };
        }

    }
}