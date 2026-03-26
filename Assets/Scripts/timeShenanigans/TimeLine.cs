
using System.Collections.Generic;

public class TimeLine
{
    // 0 = in the furthest past
    public TimeLine Predecessor { get; protected set; }
    public List<TimeLine> Successors { get; protected set; }
    public List<TimeStamp> timestamps { get; protected set; } = new List<TimeStamp>();
    public int startTick { get; protected set; }
    public int endTick { get; protected set; }
    public float startSeconds { get; protected set; }
    public float endSeconds { get; protected set; }

    public int TimelineID;
    public virtual void Init(int startT, float startS, TimeLine pre)
    {
        TimelineID = Constants.RegisteredTimelines;
        startTick = startT;
        startSeconds = startS;
        Predecessor = pre;
    }
    public virtual void AddTimestamp(TimeStamp timeStamp)
    {
        timestamps.Add(timeStamp);
        endTick = timeStamp.TickId;
        endSeconds = timeStamp.SecondsLocal;
    }
    public virtual void recordNewSuccessor(TimeLine successor)
    {
        Successors.Add(successor);
    }
    //public virtual void SplitTimeline(int splitIndex , out TimeLine TimelineBase , out TimeLine TimelineSplit)
    //{
    //    Constants.RegisterNewTimeline();

    //}
}
