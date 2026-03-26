using UnityEngine;
using System.Collections.Generic;
public class TimeDot
{
    public int Tick { get; private set; }

    public List<int> BranchTimeline { get; private set; }

    public float Seconds { get; private set; }
    public float Scale{get; private set;}

    public TimeDot(int tick, float seconds, float scale)
    {
        Tick = tick;
        Seconds = seconds;
        Scale = scale;
    }
}
