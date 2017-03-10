//*******************************//
//
// Class Name:		GameClock
// Description:		Static class which converts floating point time in seconds into strings for the scoreboard clock/timer.
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Jan 29, 2017
// Last updated:	Jan 29, 2017
//
//*******************************//

using System;

public static class GameClock
{
    // Standard digital timer
    public static string DigitalTimeConvert(float _time)
    {
        TimeSpan t = TimeSpan.FromSeconds(_time);

        string answer = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        return answer;
    }

    // Hockey countdown timer
    public static string CountdownTimer(float _time)
    {
        TimeSpan t = TimeSpan.FromSeconds(_time);
        string answer = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

        if (t.Minutes < 1) {
            answer = string.Format("{0:D1}.{1:D2}", t.Seconds, t.Milliseconds);

            if (t.Seconds < 10) {
                int milli = t.Milliseconds;
                answer = string.Format("{0:D2}.{1:D1}", t.Seconds, milli);
            }
        }

        // Time's Up!
        if (_time < 0.02f) {
            answer = "00.00";
        }

        return answer;
    }

    public static string ElapsedTimer(float _time)
    {
        TimeSpan t = TimeSpan.FromSeconds(_time);
        string ss = string.Format("{0:D1}.{1:D2}", t.Seconds, t.Milliseconds);
        return ss;
    }

    


} // end class Universal
