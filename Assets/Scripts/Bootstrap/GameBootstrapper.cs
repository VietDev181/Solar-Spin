using UnityEngine;
using System.Collections.Generic;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private CircleObjectSpawner spawner;

    [Header("Player")]
    [SerializeField] private PlayerView playerView;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerCollision playerCollision1;
    [SerializeField] private PlayerCollision playerCollision2;
    [SerializeField] private float playerRadius = 4.65f;

    private void Awake()
    {
        // Infrastructure
        SaveSystem saveSystem = new SaveSystem();

        IMathService mathService = new UnityMathService();

        CollisionService collisionService = new CollisionService(mathService);
        IDifficultyService difficultyService = new LinearDifficultyService();

        // Core
        GameService gameService = new GameService(
            saveSystem.LoadHighScore(),
            difficultyService,
            playerRadius
        );

        // State machine
        var states = new Dictionary<GameStateType, IGameState>
        {
            { GameStateType.Playing, new PlayingState(gameService) },
            { GameStateType.GameOver, new GameOverState(gameService) }
        };

        GameStateMachine stateMachine = new GameStateMachine(states);
        gameService.SetStateMachine(stateMachine);

        // Inject
        gameController.Initialize(gameService, saveSystem);
        playerView.Initialize(gameService);
        playerController.Initialize(gameService);
        spawner.Initialize(gameService);
        playerCollision1.Initialize(gameService);
        playerCollision2.Initialize(gameService);

        // Start game
        stateMachine.ChangeState(GameStateType.Playing);
    }
}