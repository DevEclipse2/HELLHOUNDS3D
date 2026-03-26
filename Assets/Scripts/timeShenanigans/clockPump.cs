using UnityEngine;
using System.Collections.Generic;

public class clockPump : MonoBehaviour
{
    public byte time;
    public float TimeScale;
    int tick;
    public float ageLocal;
    public float ageGlobal;
    public float ageRt;
    public float TimeLocalScale;
    public float TimeGlobalScale;
    public float rewindScale;

    int beat;
    TimeLine currentTimeline = new TimeLine();
    List<TimeLine> allTlines = new List<TimeLine>();

    float baseTime;
    float baseGlobalTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public virtual void ProgTime()
    {
        ageLocal += (1 / Constants.Tps * TimeLocalScale * TimeGlobalScale);
        ageGlobal += (1 / Constants.Tps * TimeGlobalScale);
        ageRt += (1 / Constants.Tps);
        TimeStamp timestamp = new TimeStamp(tick, TimeLocalScale, TimeGlobalScale, ageLocal, ageGlobal, ageRt);
        currentTimeline.AddTimestamp(timestamp);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch (time)
        {
            case Constants.Forward:
                tick++;
                //add stuff
                ProgTime();
                break;

            case Constants.FtoB:
                break;
            case Constants.Backward:
                tick--;
                break;
            case Constants.BtoF:
                //new timeline time

                TimeLine timeline = new TimeLine();
                //timeline.Init(tick, baseTime, baseGlobalTime, currentTimeline);
                ageLocal = 0;
                ageGlobal = 0;
                ageRt = 0;
                break;
        }
    }
}
