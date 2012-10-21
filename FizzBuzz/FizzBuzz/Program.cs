using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzBuzz.DataHost;
using FizzBuzz.DataObjectCategoryIdentifier;
using FizzBuzz.FizzBuzzCalcuator;

namespace FizzBuzz
{
  class Program
  {
    static void Main(string[] args)
    {
        IDataSetObject[] dataSet = DataSetProvider.ProvideData();
        DataObjectIdentifier identifer = new DataObjectIdentifier();

        foreach (var dataSetObject in dataSet)
        {
            DataObjectType type = identifer.IdentifyType(dataSetObject);

            if (type == DataObjectType.Buzz)
            {
                Buzz buzz = new Buzz(3, 2);
                buzz.TootSound();
            }

            if (type == DataObjectType.Fizz)
            {
                Fizz fizz = new Fizz(3, 2);
                fizz.TootSound();
            }

        }

        Console.ReadLine();
    }
  }
}
