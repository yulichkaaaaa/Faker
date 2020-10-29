using FakerLib;
using System;

namespace BoolGenerator
{
    class BoolGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            return context.Random.Next(0, 2) > 0;
        }
    }
}
