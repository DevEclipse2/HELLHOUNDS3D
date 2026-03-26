using UnityEngine;
using System.Collections.Generic;

public static class Constants
{
    public static readonly int Tps = 25;
    public const byte Forward  = 0;
    public const byte FtoB     = 1;
    public const byte Backward = 2;
    public const byte BtoF     = 3;
    public const byte BtoP     = 4;
    public const byte PtoB     = 5;
    public const byte FtoP     = 6;
    public const byte PtoF     = 7;
    public const byte Paused   = 8;
    public static int RegisteredTimelines;
    public static List<int> ExistingTimelines;


    public static void RegisterNewTimeline()
    {
        RegisteredTimelines++;
        ExistingTimelines.Add(RegisteredTimelines);
    }
    public static int UnregisterTimeline(int timelineId) {

        if (ExistingTimelines.Contains(timelineId))
        {
            ExistingTimelines.RemoveAt(ExistingTimelines.IndexOf(timelineId));
            return 0;
        }
        return -1;
    }
}
