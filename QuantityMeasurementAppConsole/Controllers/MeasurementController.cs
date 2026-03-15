using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppModelLayer.Core;
using QuantityMeasurementAppModelLayer.Units;

namespace QuantityMeasurementAppConsole.Controllers
{
    public class MeasurementController
    {
        private readonly IMeasurementService _service;

        public MeasurementController()
        {
            _service = new MeasurementService();
        }

        public void HandleConversion<U>(Quantity<U> q, U toUnit) where U : Enum
        {
            var result = _service.PerformConversion(q, toUnit);
            Console.WriteLine($"\n[RESULT] {q.Value} {q.Unit} is equal to {result.Value} {result.Unit}");
        }

        public void HandleAddition<U>(Quantity<U> q1, Quantity<U> q2, U target) where U : Enum
        {
            try
            {
                var result = _service.PerformAddition(q1,q2, target);
                Console.WriteLine($"\n[RESULT] {q1.Value} {q1.Unit} + {q2.Value} {q2.Unit} = {result.Value} {result.Unit}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
        }

        public void HandleSubtraction<U>(Quantity<U> q1, Quantity<U> q2, U target) where U : Enum
        {
            try
            {
                var result = _service.PerformSubtraction(q1,q2, target);
                Console.WriteLine($"\n[RESULT] {q1.Value} {q1.Unit} - {q2.Value} {q2.Unit} = {result.Value} {result.Unit}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
        }
    }
}