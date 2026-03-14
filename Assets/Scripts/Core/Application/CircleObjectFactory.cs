using System;

public class CircleObjectFactory
{
    private readonly Random random = new Random();

    public CircleObjectModel Create()
    {
        float angle = (float)(random.NextDouble() * Math.PI * 2);

        CircleObjectType type =
            random.Next(0, 4) == 0
            ? CircleObjectType.Star
            : CircleObjectType.Obstacle;

        return new CircleObjectModel(angle, type);
    }
}