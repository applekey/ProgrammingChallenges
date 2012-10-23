using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  public class RecursiveAlgo
  {
   
    #region Fields

    private int _SquareSize;

    #endregion
    #region Constructor

    public RecursiveAlgo(int squareSize)
    {
      _SquareSize = squareSize;
    }

    #endregion

    #region Public Methods

    public void DoIt()
    {
      int[][] grid = ConstructDefaultGrid(_SquareSize);
      

    }

    private int[][] ConstructDefaultGrid(int _SquareSize)
    {
      int[][] grid = Enumerable
                   .Range(0, _SquareSize)
                   .Select(i => Enumerable.Repeat(0,_SquareSize).ToArray())
                   .ToArray();
      return grid;
    }


    #endregion

    #region Private Methods

    private void RecursiveHelper(Coordinates origionalCoordinates)
    {
     


    }

    private Coordinates[] validCoordinates(Coordinates origionalCoordinates)
    {
      int x = origionalCoordinates.XCoordinate;
      int y = origionalCoordinates.YCoordinate;

      Coordinates[] additionCoordinates = new Coordinates[]
      {
        new Coordinates(-2,1),
        new Coordinates(-1,2),
        new Coordinates(1,2),
        new Coordinates(2,1),
        new Coordinates(2,-1),
        new Coordinates(1,-2),
        new Coordinates(-1,-2),
        new Coordinates(-2,-1)
      };

      List<Coordinates> newCoordinates = new List<Coordinates>();
      foreach (var coordinateAddtion in additionCoordinates)
      {

      }
     


    }

    

    


    #endregion

  }
}
