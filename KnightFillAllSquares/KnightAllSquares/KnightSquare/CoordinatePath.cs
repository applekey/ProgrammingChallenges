using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  public class CoordinatePath
  {
    #region Fields

    private List<Coordinates> _Coordinates = new List<Coordinates>();
    private readonly int _PathIdentifier;
    #endregion

    #region Properties

    public Coordinates[] Coordinates
    {
      get
      {
        if (_Coordinates.Count() != 0)
        {
          return _Coordinates.ToArray();
        }
        else
        {
          return null;
        }
      }
      private set
      {
        _Coordinates = value.ToList();
      }
    }

    public int PathIdentifier
    {
      get
      {
        return _PathIdentifier;
      }
    }

    #endregion

    public CoordinatePath()
    {

    }

    public void AddCoordinate(Coordinates coordinates)
    {
      _Coordinates.Add(coordinates);
    }

    public CoordinatePath Branch()
    {
      CoordinatePath newCoordinates = new CoordinatePath();
      newCoordinates._Coordinates = this._Coordinates;
      return newCoordinates;
    }

  }
}
