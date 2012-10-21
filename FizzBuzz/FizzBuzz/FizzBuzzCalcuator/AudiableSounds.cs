using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzBuzz.Logger;

namespace FizzBuzz.FizzBuzzCalcuator
{
  public abstract class AudiableSounds : Sounds
  {

    #region Fields

    private float  _SoundIntensityLevel;
    private readonly float _MaxSoundIntesityLevel;

    #endregion

    #region Properties

    public float SoundIntensityLevel 
    {
      get
      {
        return _SoundIntensityLevel;
      }
    }

    #endregion



    #region Constructor

    protected AudiableSounds()
    {

    }

    public AudiableSounds(float soundIntensityLevel, float maxSoundIntensityLevel)
    {
      if (soundIntensityLevel == null)
      {
        throw new ArgumentNullException("soundIntensityLevel");
      }

      if (_MaxSoundIntesityLevel == null)
      {
        throw new ArgumentNullException("maxSoundIntensityLevel");
      }

      _SoundIntensityLevel = soundIntensityLevel;
      _MaxSoundIntesityLevel = maxSoundIntensityLevel;
    }

    #endregion


    #region Public Methods

    public bool TryAdjustIntensityLevel(float newSoundLevel)
    {
      try
      {
        if (newSoundLevel == null)
        {
          throw new ArgumentNullException("newSoundLevel");
        }

        ValidateNewSoundLevel(newSoundLevel);
        _SoundIntensityLevel = newSoundLevel;

        return true;
      }
      catch (Exception ex)
      {
        MainLogger.LogException(ex.ToString());
        return false;
      }
    } 

    #endregion

    #region Private Methods

    private void ValidateNewSoundLevel(float newSoundLevel)
    {
      if (newSoundLevel == null)
      {
        throw new ArgumentNullException("newSoundLevel");
      }

      if (newSoundLevel <= 0)
      {
        throw new ArgumentException("The entered new sound level is less than or equal 0 which is invalid.");
      }

      if(newSoundLevel> _MaxSoundIntesityLevel)
      {
        throw new ArgumentException("The new sound level is larger than the max sound level intensity");
      }
    } 

    #endregion
  }
}
