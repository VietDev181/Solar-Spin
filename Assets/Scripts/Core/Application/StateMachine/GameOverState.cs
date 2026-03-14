public class GameOverState : IGameState
{
    private GameService gameService;

    public GameOverState(GameService service)
    {
        gameService = service;
    }

    public void Enter()
    {
        gameService.GameOver();
    }

    public void Exit() { }

    public void Update() { }
}