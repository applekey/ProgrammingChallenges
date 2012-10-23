using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  public class Visit
  {
    #region Fields

    private readonly List<int> _PathIdentifiers = new List<int>();

    #endregion


    #region Constructor

    public Visit()
    {

    }

    #endregion

    #region Methods

    public void AddVisit(int pathidentifier)
    {
      _PathIdentifiers.Add(pathidentifier);
    }

    public bool HasVisit(int pathIdentifier)
    {
      if (_PathIdentifiers.Count == 0)
      {
        return false;
      }

      foreach (var identifer in _PathIdentifiers)
      {
        if(identifer == pathIdentifier)
          return true;
      }

      return false;

    }

    #endregion
  }
}
