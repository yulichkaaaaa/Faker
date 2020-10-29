using FakerLib.Generators;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FakerLib
{
    public class Faker
    {
        private List<IGenerator> generators = new List<IGenerator>() {new IntGenerator(),
                                                                      new BoolGenerator(),
                                                                      new StrGenerator(), 
                                                                      new DoubleGenerator(), 
                                                                      new ListGenerator(),
                                                                      new DateTimeGenerator()};

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public Faker()
        {
            generators = new PluginLoader().RefreshPlugins();
            generators.Add(new ListGenerator());
            generators.Add(new DateTimeGenerator());
            generators.Add(new StrGenerator());
            generators.Add(new DoubleGenerator());
            int i = 9;
        }
        internal object Create(Type t)
        {
            foreach (IGenerator generator in generators)
            {
                if (generator.CanGenerate(t))
                    return generator.Generate(new GeneratorContext(new Random(), t, this));
            }

            ConstructorInfo[] constructors = t.GetConstructors();
            int maxLen = MaxLengthConstr(constructors);
            ConstructorInfo constructor = constructors[maxLen];
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] consargs = GenerateParams(parameters);
            object reflectOb = constructor.Invoke(consargs);

            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (IGenerator generator in generators)
                {
                    if (generator.CanGenerate(property.PropertyType))
                    {
                        property.SetValue(reflectOb, generator.Generate(new GeneratorContext(new Random(), property.PropertyType, this)));
                    }
                    else
                    {
                        property.SetValue(reflectOb, Create(property.PropertyType));
                    }
                }
            }

            FieldInfo[] fields = t.GetFields();
            foreach (FieldInfo field in fields)
            {
                foreach (IGenerator generator in generators)
                {
                    if (generator.CanGenerate(field.FieldType))
                    {
                        field.SetValue(reflectOb, generator.Generate(new GeneratorContext(new Random(), field.FieldType, this)));
                    }
                    else 
                    {
                        field.SetValue(reflectOb, Create(field.FieldType));
                    }
                }
            }

            return reflectOb;

        }
        private int MaxLengthConstr(ConstructorInfo[] constructors)
        {
            int max = 0;
            for(int i = 1; i < constructors.Length; i++)
            {
                ParameterInfo[] CurrParameters = constructors[i].GetParameters();
                ParameterInfo[] MaxParameters = constructors[max].GetParameters();
                if (CurrParameters.Length > MaxParameters.Length) {
                    max = i;
                }
            }
            return max;
        }

        private object[] GenerateParams(ParameterInfo[] parameters)
        {
            object[] generatedParams = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                foreach (IGenerator generator in generators)
                {
                    if (generator.CanGenerate(parameters[i].ParameterType))
                        generatedParams[i] = generator.Generate(new GeneratorContext(new Random(), parameters[i].ParameterType, this));
                }
            }
            return generatedParams;
        }

    }
}
