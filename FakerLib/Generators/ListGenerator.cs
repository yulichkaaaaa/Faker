using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FakerLib.Generators
{
    class ListGenerator : IGenerator
    {
        bool IGenerator.CanGenerate(Type type)
        {
            return type.GetInterfaces().Contains(typeof(IList));
        }

        object IGenerator.Generate(GeneratorContext context)
        {
            IList list = (IList)Activator.CreateInstance(context.TargetType);
            Type itemType = list.GetType().GetGenericArguments().Single();
            int itemCount = new Random().Next(9)+1;
            for (int i = 0; i < itemCount; i++)
            {
                list.Add(context.Faker.Create(itemType));
            }
            return list;
        }
    }
}
