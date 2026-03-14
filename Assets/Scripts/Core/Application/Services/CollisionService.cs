public class CollisionService
{
    private readonly IMathService math;

    public CollisionService(IMathService mathService)
    {
        math = mathService;
    }

    public bool CheckCollision(float playerAngleRad, float obstacleAngleRad, float thresholdDeg)
    {
        float delta = math.DeltaAngleRad(playerAngleRad, obstacleAngleRad);
        float deltaDeg = math.Abs(delta * 180f / 3.14159265359f);

        return deltaDeg < thresholdDeg;
    }
}