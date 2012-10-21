using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FizzBuzz.DataHost
{
    public static class DataSetProvider
    {
        public static IDataSetObject[] ProvideData()
        {
            List<IDataSetObject> dataSetObject = new List<IDataSetObject>();
            for (int i = 0; i < 100; i++)
            {
                DataSetObject dataObject = new DataSetObject(i);
                dataSetObject.Add(dataObject);
            }

            return dataSetObject.ToArray();

        }
    }
}
