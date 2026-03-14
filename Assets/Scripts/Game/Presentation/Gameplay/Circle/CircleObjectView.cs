using UnityEngine;

public class CircleObjectView : MonoBehaviour
{
    private GameService gameService;

    [SerializeField] private float speed = 5f;

    private Vector3 direction;

    public void Initialize(GameService service)
    {
        gameService = service;

        direction = (-transform.position).normalized;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Vector3.zero) < 0.2f)
        {
            gameObject.SetActive(false);
        }
    }
}