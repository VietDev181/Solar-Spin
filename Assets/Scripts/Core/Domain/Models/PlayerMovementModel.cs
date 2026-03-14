public class PlayerMovementModel
{
    public float Radius { get; }

    public float Angle { get; private set; }
    public float Speed { get; private set; }

    private int direction = 1;

    public PlayerMovementModel(float radius, float startSpeed)
    {
        Radius = radius;
        Speed = startSpeed;
    }

    public void Update(float deltaTime)
    {
        Angle += direction * Speed * deltaTime;
    }

    public void SetSpeed(float value)
    {
        Speed = value;
    }

    public void ToggleDirection()
    {
        direction *= -1;
    }

    public void Reset(float startSpeed)
    {
        Angle = 0;
        Speed = startSpeed;
        direction = 1;
    }
}