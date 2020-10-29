using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Generators
{
    class DateTimeGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            int year = context.Random.Next(1, 2021);
            int month = context.Random.Next(1, 13);
            int day = context.Random.Next(1, 32);
            int hour = context.Random.Next(24);
            int minute = context.Random.Next(60);
            int second = context.Random.Next(60);
            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
