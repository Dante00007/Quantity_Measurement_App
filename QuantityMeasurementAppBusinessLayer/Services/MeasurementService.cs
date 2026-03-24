using QuantityMeasurementAppModelLayer.Core;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.DTO;

using QuantityMeasurementAppModelLayer.Units;
using QuantityMeasurementAppRepoLayer;
using QuantityMeasurementAppBusinessLayer.Interface;

using QuantityMeasurementAppBusinessLayer.Exceptions;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementHistoryRepository _repository;

        public MeasurementService()
        {

            _repository = new MeasurementHistoryRepository();
        }

        private Enum ParseUnit(Type unitType, string unitName)
        {
            try
            {
                return (Enum)Enum.Parse(unitType, unitName, ignoreCase: true);
            }
            catch (ArgumentException)
            {
                throw new InvalidUnitNameException(unitName, unitType.Name);
            }
        }
        private Type GetUnitFromIndex(int index)
        {
            return index switch
            {
                1 => typeof(LengthUnit),
                2 => typeof(WeightUnit),
                3 => typeof(VolumeUnit),
                4 => typeof(TemperatureUnit),
                _ => throw new InvalidUnitException($"{index} is an Invalid index. In MeasurementService.cs"),
            };
        }
        public QuantityDTO PerformConversion(QuantityDTO q, string toUnit)
        {
            Type unitType = GetUnitFromIndex(q.EnumIndex);

            Enum unit = ParseUnit(unitType, q.Unit);
            Enum targetUnit = ParseUnit(unitType, toUnit);

            Quantity quantity = new Quantity(q.Value, unit);
            QuantityDTO res = quantity.ConvertTo(targetUnit);

            AddToHistory(q, null, res, "Conversion");

            return res;
        }

        public QuantityDTO PerformAddition(QuantityDTO q1, QuantityDTO q2, string toUnit)
        {
            if (q1.EnumIndex != q2.EnumIndex)
            {
                throw new IncompatibleUnitException("Cannot perform addition on different unit types .");
            }

            Type unitType = GetUnitFromIndex(q1.EnumIndex);

            Enum unit1 = ParseUnit(unitType, q1.Unit);
            Enum unit2 = ParseUnit(unitType, q2.Unit);
            Enum targetUnit = ParseUnit(unitType, toUnit);

            Quantity quantity1 = new Quantity(q1.Value, unit1);
            Quantity quantity2 = new Quantity(q2.Value, unit2);
            QuantityDTO result = quantity1.Add(quantity2, targetUnit);

            AddToHistory(q1, q2, result, "Addition");
            return result;
        }

        public QuantityDTO PerformSubtraction(QuantityDTO q1, QuantityDTO q2, string toUnit)
        {
            if (q1.EnumIndex != q2.EnumIndex)
            {
                throw new IncompatibleUnitException("Cannot perform addition on different unit types .");
            }

            Type unitType = GetUnitFromIndex(q1.EnumIndex);

            Enum unit1 = ParseUnit(unitType, q1.Unit);
            Enum unit2 = ParseUnit(unitType, q2.Unit);
            Enum targetUnit = ParseUnit(unitType, toUnit);

            Quantity quantity1 = new Quantity(q1.Value, unit1);
            Quantity quantity2 = new Quantity(q2.Value, unit2);

            QuantityDTO result = quantity1.Subtract(quantity2, targetUnit);

            AddToHistory(q1, q2, result, "Subtraction");
            return result;
        }

        public bool CheckEquality(QuantityDTO q1, QuantityDTO q2)
        {
            if (q1.EnumIndex != q2.EnumIndex)
            {
                throw new IncompatibleUnitException("Cannot perform addition on different unit types .");
            }

            Type unitType = GetUnitFromIndex(q1.EnumIndex);

            Enum unit1 = ParseUnit(unitType, q1.Unit);
            Enum unit2 = ParseUnit(unitType, q2.Unit);

            double val1 = q1.Value;
            double val2 = q2.Value;
            var quantity1 = new Quantity(val1, unit1);
            var quantity2 = new Quantity(val2, unit2);

            return quantity1.Equals(quantity2);
        }

        private void AddToHistory(QuantityDTO q1, QuantityDTO? q2, QuantityDTO result, string operation)
        {
            QuantityMeasurementHistoryEntity history = new QuantityMeasurementHistoryEntity();

            history.InputValue1 = q1.Value;
            history.InputUnit1 = q1.Unit;
            history.InputValue2 = q2 == null ? 0 : q2.Value;
            history.InputUnit2 = q2 == null ? "" : q2.Unit;
            history.TargetUnit = result.Unit;
            history.Operation = operation;
            history.ResultValue = result.Value;
            history.ResultUnit = result.Unit; ;

            _repository.SaveHistory(history);
        }


    }
}