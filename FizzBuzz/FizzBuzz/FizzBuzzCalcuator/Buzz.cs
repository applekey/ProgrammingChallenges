using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using FizzBuzz.Logger;

namespace FizzBuzz.FizzBuzzCalcuator
{

  public class Buzz :AudiableSounds
  {

      #region Fields

      private readonly string _SoundName;

      #endregion


      #region Properties

      public override string SoundName
      {
          get
          {
              return _SoundName;
          }

      }

      #endregion


      #region Constructor
      public Buzz(float soundIntensityLevel, float maxSoundIntensityLevel)
          : base(soundIntensityLevel, maxSoundIntensityLevel)
      {
          _SoundName = "Buzz";
      }
      #endregion


    protected override void OnCreateSound()
    {
      OnCreateSound(null);
    }

    protected override void OnCreateSound(CancellationToken? cts)
    {
        if (cts.HasValue && cts.Value.IsCancellationRequested)
        {
            string errorMessage = string.Format(CultureInfo.InvariantCulture, "OnSoundCreated has being cancelled");

            MainLogger.LogRunMessage(errorMessage, Enums.ApplicationLog.Cancel);
            throw new OperationCanceledException(errorMessage);
        }
        string message = string.Format(CultureInfo.InvariantCulture, "Intensity: {0},Buzz ", SoundIntensityLevel.ToString());
        Console.WriteLine(message);
    }

  }
}
