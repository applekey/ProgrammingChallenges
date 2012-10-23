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
    private Visit[] _Grid;
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

      int pathIdentifer = 0;
      RecursivePaths(new Coordinates(0, 0), coordinatePath,0);

    }

    #endregion

    #region Private Methods

    private Visit[] ConstructDefaultGrid(int _SquareSize)
    {
      Visit[] grid = new Visit[_SquareSize*_SquareSize];
      for (int i = 0; i < grid.Length; i++)
      {
        grid[i] = new Visit();
      }
     
      return grid;
    }


    private void RecursivePaths(Coordinates coordinate,CoordinatePath coordinatePath, int pathIdentifer)
    {
      if (IsCoordinateMarkedOnGrid(coordinate,pathIdentifer))
      {
        return;
      }


      MarkCoordinateOnGrid(coordinate,pathIdentifer);

      Coordinates[] newCordinates = GetNewValidCoordinates(coordinate);

      int depth = coordinatePath.Coordinates.Length;
      Console.WriteLine("depth is" + depth.ToString());

      int newPathIdentifer;

      foreach (var coordiante in newCordinates)
      {
        if (!IsCoordinateMarkedOnGrid(coordiante,pathIdentifer))
        {
          //this is the first one
          CoordinatePath cordinatePathToPassOn;
          if (coordinatePath.Coordinates.Length == depth)
          {
            coordinatePath.AddCoordinate(coordiante);
            cordinatePathToPassOn = coordinatePath;
            newPathIdentifer = pathIdentifer;
          }
          else
          {
            CoordinatePath newCordinatePath = coordinatePath.Branch();
            _CoordinatePaths.Add(newCordinatePath);
            cordinatePathToPassOn = newCordinatePath;
            newPathIdentifer = pathIdentifer + 1;
          }

          RecursivePaths(coordiante, cordinatePathToPassOn, newPathIdentifer);
          
        }
      }
    }

    private bool IsCoordinateMarkedOnGrid(Coordinates coordiante, int identifier)
    {

      Visit visit = _Grid[coordiante.XCoordinate + coordiante.YCoordinate*_SquareSize];
      if (visit.HasVisit(identifier))
      {
        return true;
      }
      else
      {
        return false;
      }

    }

    private void MarkCoordinateOnGrid(Coordinates coordinate, int identifier)
    {
      Visit visit = _Grid[coordinate.XCoordinate + coordinate.YCoordinate * _SquareSize];
      
      if(visit.HasVisit(identifier))
      {
        throw new InvalidOperationException("grid coordinate already set to 1");
      }
      Console.WriteLine(coordinate.XCoordinate.ToString() +" " + coordinate.YCoordinate.ToString());

      visit.AddVisit(identifier);
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
