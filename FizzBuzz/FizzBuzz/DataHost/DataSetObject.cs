using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FizzBuzz.DataHost
{
    public class DataSetObject : FizzBuzz.DataHost.IDataSetObject
    {

        #region Fields

        private readonly int _DataNumber;

        #endregion

        #region Properties

        public int DataNumber
        {
            get
            {
                return _DataNumber;
            }
        }

        #endregion


        #region Constructor

        public DataSetObject(int dataNumber)
        {
            if (dataNumber == null)
            {
                throw new ArgumentNullException("dataNumber");
            }

            _DataNumber = dataNumber;
        }

        #endregion




       
    }
}
