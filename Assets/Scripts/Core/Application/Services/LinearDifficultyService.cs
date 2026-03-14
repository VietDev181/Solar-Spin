using System;

public class LinearDifficultyService : IDifficultyService
{
    public float GetSpawnInterval(int score)
    {
        float baseInterval = 2f;
        float decrease = score * 0.05f;

        return Math.Max(0.5f, baseInterval - decrease);
    }

    public float GetPlayerSpeed(int score)
    {
        return 2.5f;
    }
}