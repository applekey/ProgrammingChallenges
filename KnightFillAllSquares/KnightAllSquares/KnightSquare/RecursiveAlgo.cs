using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  public class RecursiveAlgo
  {
    struct Coordinates
    {
      int x;
      int y;
    };

    #region Fields

    private int _SquareSize;
    private Coordinates _Coordinate;

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
      return 
    }

    


    #endregion

  }
}
