using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using FizzBuzz.Enums;

namespace FizzBuzz.Logger
{
  public static class MainLogger
  {

    public static void LogException(string exceptionMessage)
    {
      if (string.IsNullOrWhiteSpace(exceptionMessage))
      {
        return;
      }
      string messageToLog = string.Format(CultureInfo.InvariantCulture,
                                          "An exception occured at:{0} with message {1}",
                                          DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), 
                                          exceptionMessage);
      OnLogMessage(messageToLog);
    }



    public static void LogRunMessage(string runMessage,ApplicationLog applicationSection)
    {
      if (string.IsNullOrWhiteSpace(runMessage))
      {
        return;
      }

      if (applicationSection == ApplicationLog.None)
      {
        return;
      }

      string messageToLog = string.Format(CultureInfo.InvariantCulture, "{0}:runMessage",applicationSection.ToString(),runMessage);

      OnLogMessage(messageToLog);

    }

    private static void OnLogMessage(string logMessage)
    {
      try
      {
        //TODO: FILL THIS IN
      }
      catch (Exception)
      {

        throw;
      }
      finally
      {
        //TODO CLOSE THE FILE ACCESS
      }


    }

  }
}
