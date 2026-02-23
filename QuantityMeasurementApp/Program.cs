// See https://aka.ms/new-console-template for more information

using QuantityMeasurementApp;   
using QuantityMeasurementApp.models;

QuantityLength length1 = new QuantityLength(1, LengthUnit.FEET);
QuantityLength length2 = new QuantityLength(12, LengthUnit.INCH);

Console.WriteLine(QuantityMeasurementApplication.DemonstrateLengthEquality(length1, length2));
