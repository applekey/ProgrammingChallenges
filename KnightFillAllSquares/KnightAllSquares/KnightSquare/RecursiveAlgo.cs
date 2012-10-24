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
      _CoordinatePaths.Add(coordinatePath);

      RecursivePaths(new Coordinates(0, 0), coordinatePath);
      PrintOutResults();

    }

    public void PrintOutResults()
    {
      foreach (var path in _CoordinatePaths)
      {
        Console.WriteLine("Path is ");
        foreach (var coordiantes in path.Coordinates)
        {
          Console.WriteLine(coordiantes.XCoordinate + " " + coordiantes.YCoordinate);
        }
        Console.WriteLine("");
        
      }
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

    private void RecursivePaths(Coordinates coordinate,CoordinatePath coordinatePath)
    {
      if (IsCoordinateAlreadyVisitedOnPath(coordinate, coordinatePath))
      {
        return;
      }

      AddCoordinateVisitOnPath(coordinate, coordinatePath);

      Coordinates[] newCoordinates = GenerateNewValidCoordinates(coordinate, coordinatePath);

      if (newCoordinates == null)
      {
        return;
      }

      Console.WriteLine("number of choices is" + newCoordinates.Length.ToString());
      CoordinatePath tmp =  coordinatePath.Branch();
      for (int i = 0; i < newCoordinates.Length; i++)
			{
        if (i == 1)
        {
        }

        //this is the first one
        CoordinatePath cordinatePathToPassOn;
        if (i == 0)
        {
          cordinatePathToPassOn = coordinatePath;
        }
        else
        {
          CoordinatePath path = tmp.Branch();
          _CoordinatePaths.Add(path);
          cordinatePathToPassOn = path;
        }

        RecursivePaths(newCoordinates[i], cordinatePathToPassOn);
      }
    }

    private Coordinates[] GenerateNewValidCoordinates(Coordinates coordinate, CoordinatePath coordinatePath)
    {
      List<Coordinates> validCoordiantes = new List<Coordinates>();
      Coordinates[] newCordinates = GetNewValidCoordinates(coordinate);
      foreach (var coord in newCordinates)
      {

        if (!IsCoordinateAlreadyVisitedOnPath(coord, coordinatePath))
        {
          validCoordiantes.Add(coord);
        }
      }
      if (validCoordiantes.Count() != 0)
      {
        return validCoordiantes.ToArray();
      }
      else
      {
        return null;
      }
      
    }

    private bool IsCoordinateAlreadyVisitedOnPath(Coordinates coordiante, CoordinatePath coordinatePath)
    {
      if (coordinatePath.IsCoordinateOnPath(coordiante))
        return true;
      else
        return false;

    }

    private void AddCoordinateVisitOnPath(Coordinates coordinate, CoordinatePath coordinatePath)
    {
      coordinatePath.AddCoordinate(coordinate);
     
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
