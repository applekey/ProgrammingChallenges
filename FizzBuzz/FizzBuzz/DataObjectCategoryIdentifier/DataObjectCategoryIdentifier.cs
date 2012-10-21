using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzBuzz.DataHost;

namespace FizzBuzz.DataObjectCategoryIdentifier
{
    public class DataObjectIdentifier
    {
        #region Constructor

        public DataObjectIdentifier()
        {

        }

        #endregion

        #region Public Methods

        public DataObjectType IdentifyType(IDataSetObject dataSetObject)
        {
            ValidateDataSetObject(dataSetObject);
            int dataNumber = dataSetObject.DataNumber;
            if (dataNumber % 3 == 0)
            {
                return DataObjectType.Buzz;
            }
            else if (dataNumber % 5 == 0)
            {
                return DataObjectType.Fizz;
            }
            else
            {
                return DataObjectType.General;
            }
        }

        private static void ValidateDataSetObject(IDataSetObject dataSetObject)
        {
            if (dataSetObject == null)
            {
                throw new ArgumentNullException("dataSetObject");
            }

        }

        
        #endregion


    }
}
