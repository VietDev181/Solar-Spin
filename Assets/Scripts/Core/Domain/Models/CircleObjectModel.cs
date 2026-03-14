public enum CircleObjectType
{
    Obstacle,
    Star
}

public class CircleObjectModel
{
    public float Angle { get; }
    public CircleObjectType Type { get; }

    public CircleObjectModel(float angle, CircleObjectType type)
    {
        Angle = angle;
        Type = type;
    }
}