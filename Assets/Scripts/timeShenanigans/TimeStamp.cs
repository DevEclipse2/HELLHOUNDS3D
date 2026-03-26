using UnityEngine;

public class TimeStamp
{
    public int TickId {  get; protected set; }
    public float TimeScale { get; protected set; }
    public float TimeScaleGlobal { get; protected set; }

    public float SecondsLocal { get; protected set; } // expressed as a delta of the timeline start
    public float SecondsGlobal { get; protected set; }
    public float SecondsInRealTime { get; protected set; }

    public TimeStamp(int tickId, float timeScale, float timeScaleGlobal, float secondsLocal, float secondsGlobal, float secondsInRealTime)
    {
        TickId = tickId;
        TimeScale = timeScale;
        SecondsLocal = secondsLocal;
        SecondsGlobal = secondsGlobal;
        SecondsInRealTime = secondsInRealTime;
        TimeScaleGlobal = timeScaleGlobal;
    }
}
