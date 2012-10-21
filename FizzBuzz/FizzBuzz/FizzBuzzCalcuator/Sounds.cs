using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FizzBuzz.FizzBuzzCalcuator
{
  public abstract class Sounds
  {

    #region Properties

    public abstract string SoundName { get;}
   
    #endregion

    #region Public Methods

    public void TootSound()
    {
        TootSound(null);
    }

    public void TootSound(CancellationToken? cts)
    {
      if (SoundName == null)
      {
        throw new ArgumentNullException("soundName");
      }

      if (cts != null)
      {
        OnCreateSound();
      }
      else
      {
        OnCreateSound(cts);
      }
    }

    #endregion

    #region Private Methods

    protected abstract void OnCreateSound();

    protected abstract void OnCreateSound(CancellationToken? cts);

    #endregion


  }
}
