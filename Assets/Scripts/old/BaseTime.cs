using UnityEngine;
using System.Collections.Generic;
public class BaseTime : MonoBehaviour
{
    public float LocalTimeScale { get; protected set;}
    protected Rigidbody body;
    public bool Paused;
    public List<KeyFrame> keyFrames = new List<KeyFrame>();
    public List<int> frameTick = new List<int>();
    int currentRealTick;
    int currentRewindTick;
    public bool rewinding;
    public float MarginPos = 0.005f;
    public float MarginRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        KeyFrame frame = new KeyFrame(transform.position, transform.rotation , Vector3.zero);
        keyFrames.Add(frame);
        frameTick.Add(currentRealTick);
    }
    protected virtual void insertKf()
    {
        if((transform.position - keyFrames[keyFrames.Count - 1].Position).magnitude > MarginPos || (transform.rotation.eulerAngles - keyFrames[keyFrames.Count - 1].Rotation.eulerAngles).magnitude > MarginRot)
        {
            KeyFrame frame = new KeyFrame(transform.position, transform.rotation , body.linearVelocity);
            keyFrames.Add(frame);
            frameTick.Add(currentRewindTick);
        }

    }
    protected virtual void rewindKf( int keyFrameId)
    {
        body.isKinematic = true;
        body.position = keyFrames[keyFrameId].Position;
        body.rotation = keyFrames[keyFrameId].Rotation;
        body.linearVelocity = keyFrames[keyFrameId].Velocity;
    }    
    protected virtual void truncateKf()
    {

    }

    // fixed update is 25 times per second
    public virtual void FixedUpdate()
    {
        if (!Paused)
        {
            if (!rewinding)
            {
                currentRealTick++;
                currentRewindTick++;
                body.isKinematic = false;
                insertKf();
            }
            else
            {
                currentRewindTick--;
                for (int i = frameTick.Count - 1; i >= 0; i--) 
                {
                    if (frameTick[i] == currentRewindTick)
                    {
                        rewindKf(i);
                        break;
                    }
                }
            }
        }
    }
}
