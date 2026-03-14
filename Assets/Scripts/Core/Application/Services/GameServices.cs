using System;

public class GameService
{
    private readonly ScoreModel scoreModel;
    private readonly IDifficultyService difficultyService;

    private IGameStateMachine stateMachine;
    private PlayerMovementModel player;

    public event Action<int> OnScoreChanged;
    public event Action<int, int> OnGameOver;

    private float scoreTimer;

    public GameService(
        int highScore,
        IDifficultyService difficulty, float playerRadius)
    {
        scoreModel = new ScoreModel(highScore);
        difficultyService = difficulty;

        player = new PlayerMovementModel(playerRadius, 2.5f);
    }

    public void SetStateMachine(IGameStateMachine machine)
    {
        stateMachine = machine;
    }

    public void Update(float deltaTime)
    {
        stateMachine?.Update();

        if (stateMachine.CurrentStateType != GameStateType.Playing)
            return;

        // Player quay với tốc độ cố định
        player.Update(deltaTime);
    }

    public void ToggleDirection()
    {
        if (stateMachine.CurrentStateType != GameStateType.Playing)
            return;

        player.ToggleDirection();
    }

    public float GetPlayerAngle() => player.Angle;
    public float GetPlayerRadius() => player.Radius;

    public void AddScore(int value)
    {
        scoreModel.AddScore(value);
        OnScoreChanged?.Invoke(scoreModel.CurrentScore);
    }

    public void CollectStar()
    {
        if (stateMachine.CurrentStateType != GameStateType.Playing)
            return;

        AddScore(10);
    }

    public void ChangeState(GameStateType type)
    {
        stateMachine?.ChangeState(type);
    }

    public void ResetGame()
    {
        scoreModel.Reset();
        OnScoreChanged?.Invoke(scoreModel.CurrentScore);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(scoreModel.CurrentScore, scoreModel.HighScore);
    }

    public float GetSpawnInterval()
    {
        return difficultyService.GetSpawnInterval(scoreModel.CurrentScore);
    }

    public int GetHighScore() => scoreModel.HighScore;
}