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
    private int[][] _Grid;
    private readonly List<CoordinatePath> _CoordinatePaths = new List<CoordinatePath>();
    

    #endregion

    #region Constructor

    public RecursiveAlgo(int squareSize)
    {
      _SquareSize = squareSize;
    }

    #endregion

    #region Public Methods

    public void GeneratePaths()
    {
      _Grid = ConstructDefaultGrid(_SquareSize);
      CoordinatePath coordinatePath = new CoordinatePath();
      coordinatePath.AddCoordinate(new Coordinates(0, 0));
      _CoordinatePaths.Add(coordinatePath);
      RecursivePaths(new Coordinates(0, 0), coordinatePath);

    }

    #endregion

    #region Private Methods

    private int[][] ConstructDefaultGrid(int _SquareSize)
    {
      int[][] grid = Enumerable
                   .Range(0, _SquareSize)
                   .Select(i => Enumerable.Repeat(0, _SquareSize).ToArray())
                   .ToArray();
      return grid;
    }


    private void RecursivePaths(Coordinates coordinate,CoordinatePath coordinatePath)
    {
      if (IsCoordinateMarkedOnGrid(coordinate))
      {
        return;
      }


      MarkCoordinateOnGrid(coordinate);

      Coordinates[] newCordinates = GetNewValidCoordinates(coordinate);

      int depth = coordinatePath.Coordinates.Length;
      Console.WriteLine("depth is" + depth.ToString());

      foreach (var coordiante in newCordinates)
      {
        if (!IsCoordinateMarkedOnGrid(coordiante))
        {
          //this is the first one
          CoordinatePath cordinatePathToPassOn;
          if (coordinatePath.Coordinates.Length == depth)
          {
            coordinatePath.AddCoordinate(coordiante);
            cordinatePathToPassOn = coordinatePath;
          }
          else
          {
            CoordinatePath newCordinatePath = coordinatePath.Branch();
            _CoordinatePaths.Add(newCordinatePath);
            cordinatePathToPassOn = newCordinatePath;
          }

          RecursivePaths(coordiante, cordinatePathToPassOn);
          
        }
      }
    }

    private bool IsCoordinateMarkedOnGrid(Coordinates coordiante)
    {
      if (_Grid[coordiante.XCoordinate][coordiante.YCoordinate] == 1)
      {
        return true;
      }
      else
      {
        return false;
      }

    }

    private void MarkCoordinateOnGrid(Coordinates coordinate)
    {
      int gridCord = _Grid[coordinate.XCoordinate][coordinate.YCoordinate];

      if(gridCord == 1)
      {
        throw new InvalidOperationException("grid coordinate already set to 1");
      }
      Console.WriteLine(coordinate.XCoordinate.ToString() +" " + coordinate.YCoordinate.ToString());
      _Grid[coordinate.XCoordinate][coordinate.YCoordinate] = 1;
    }

    private bool ValidateCoordinates(Coordinates coordinates)
    {
      if (coordinates.XCoordinate < 0 || coordinates.XCoordinate > _SquareSize - 1)
      {
        return false;
      }

      else if (coordinates.YCoordinate < 0 || coordinates.YCoordinate > _SquareSize - 1)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    private Coordinates[] GetNewValidCoordinates(Coordinates origionalCoordinates)
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
        Coordinates newCoordinate = origionalCoordinates + coordinateAddtion;
        if (ValidateCoordinates(newCoordinate))
        {
          newCoordinates.Add(newCoordinate);
        }
      }
      return newCoordinates.ToArray();
     
    }

    

    


    #endregion

  }
}
