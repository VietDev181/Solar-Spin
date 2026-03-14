using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIGame uiGame;
    [SerializeField] private AudioService audioService;

    private GameService gameService;
    private SaveSystem saveSystem;

    public void Initialize(GameService service, SaveSystem save)
    {
        gameService = service;
        saveSystem = save;

        gameService.OnScoreChanged += uiGame.UpdateScore;
        gameService.OnGameOver += HandleGameOver;
    }

    private void Start()
    {
        audioService.PlayGameBGM();
    }

    private void Update()
    {
        gameService.Update(Time.deltaTime);
    }

    public void AddScore(int value)
    {
        gameService.AddScore(value);
    }

    public float GetSpawnInterval()
    {
        return gameService.GetSpawnInterval();
    }

    public void GameOver()
    {
        gameService.ChangeState(GameStateType.GameOver);
    }

    private void HandleGameOver(int current, int high)
    {
        saveSystem.SaveHighScore(high);
        audioService.PlayGameOverBGM();
        uiGame.ShowGameOver(current, high);
    }

    private void OnDestroy()
    {
        if (gameService != null)
        {
            gameService.OnScoreChanged -= uiGame.UpdateScore;
            gameService.OnGameOver -= HandleGameOver;
        }
    }
}