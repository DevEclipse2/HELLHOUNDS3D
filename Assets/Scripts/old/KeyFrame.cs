using UnityEngine;

public class KeyFrame
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Vector3 Velocity { get; private set; }

    public KeyFrame(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        Position = position;
        Rotation = rotation;
        Velocity = velocity;
    }

}
