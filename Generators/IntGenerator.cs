using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    class IntGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            return context.Random.Next(1, 100);
        }
    }
}
