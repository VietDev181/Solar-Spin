using UnityEngine;

public class UnityMathService : IMathService
{
    public float Abs(float value)
    {
        return Mathf.Abs(value);
    }

    public float DeltaAngleRad(float a, float b)
    {
        float delta = Mathf.DeltaAngle(a * Mathf.Rad2Deg, b * Mathf.Rad2Deg);
        return delta * Mathf.Deg2Rad;
    }
}