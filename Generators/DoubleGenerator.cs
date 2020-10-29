using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    class DoubleGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
           return type == typeof(double);
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
}
