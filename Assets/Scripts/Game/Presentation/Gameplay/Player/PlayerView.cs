using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    private GameService gameService;

    public void Initialize(GameService service)
    {
        gameService = service;
    }

    private void Update()
    {
        if (gameService == null)
            return;

        float angle = gameService.GetPlayerAngle();
        float radius = gameService.GetPlayerRadius();

        // Player 1
        Vector3 pos1 = new Vector3(
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        ) * radius;

        player1.position = pos1;

        // Player 2 (đối diện 180°)
        float angle2 = angle + Mathf.PI;

        Vector3 pos2 = new Vector3(
            Mathf.Cos(angle2),
            Mathf.Sin(angle2),
            0
        ) * radius;

        player2.position = pos2;
    }
}