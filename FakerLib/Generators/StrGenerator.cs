using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Generators
{
    class StrGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
            return type == typeof(string);
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            int len = context.Random.Next(1, 15);
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += (char)context.Random.Next('a', 'z');
            }
            return result;
        }
    }
}
