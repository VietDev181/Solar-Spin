using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerColor playerColor;
    private GameService gameService;

    public void Initialize(GameService service)
    {
        gameService = service;
    }

    private void Awake()
    {
        playerColor = GetComponent<PlayerColor>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StarView star = other.GetComponent<StarView>();
        if (star != null)
        {
            gameService.AddScore(10);
            other.gameObject.SetActive(false);
            return;
        }

        TrapColor trap = other.GetComponent<TrapColor>();

        if (trap == null)
            return;

        if (trap.colorType == playerColor.colorType)
        {
            gameService.AddScore(1);
            playerColor.RandomColor();
            other.gameObject.SetActive(false);
        }
        else
        {
            gameService.GameOver();
        }
    }
}