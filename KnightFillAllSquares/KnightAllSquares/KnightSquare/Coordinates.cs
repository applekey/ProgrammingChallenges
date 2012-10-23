using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  public class Coordinates
  {

    #region Private Methods

    private readonly int _XCoordinate;
    private readonly int _YCoordinate;
    
    #endregion
    
    #region Properties 

    public int XCoordinate
    {
      get
      {
        return _XCoordinate;
      }
    }

    public int YCoordinate
    {
      get
      {
        return _YCoordinate;
      }
    }


    #endregion

    #region Constructor

    public Coordinates(int x, int y)
    {
      _XCoordinate = x;
      _YCoordinate = y;
    }

    #endregion

    #region OverRide Methods

    public static Coordinates operator + (Coordinates cord1, Coordinates cor2)
    {
      
      int x = cord1._XCoordinate+cor2._XCoordinate;
      int y = cord1._YCoordinate+cor2._YCoordinate;

      return new Coordinates(x, y);

    }

    #endregion

  }
}
