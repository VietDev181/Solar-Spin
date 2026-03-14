using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameService gameService;

    public void Initialize(GameService service)
    {
        gameService = service;
    }

    private void Update()
    {
        if (gameService == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            gameService.ToggleDirection();
        }
    }
}