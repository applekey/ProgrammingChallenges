using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightSquare
{
  class Program
  {
    static void Main(string[] args)
    {

      RecursiveAlgo algo = new RecursiveAlgo(3);
      algo.GeneratePaths();
      Console.Read();

    }
  }
}
