using UnityEngine;

public class CircleObjectSpawner : MonoBehaviour
{
    [SerializeField] private CircleObjectPool obstaclePool;
    [SerializeField] private CircleObjectPool starPool;

    [SerializeField] private float spawnRadius = 10f; // spawn ngoài màn
    [SerializeField] private float starChance = 0.25f;

    private GameService gameService;

    private float spawnTimer;

    public void Initialize(GameService service)
    {
        gameService = service;
    }

    private void Update()
    {
        if (gameService == null)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= gameService.GetSpawnInterval())
        {
            Spawn();
            spawnTimer = 0f;
        }
    }

    private void Spawn()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 pos = new Vector3(
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        ) * spawnRadius;

        bool isStar = Random.value < starChance;

        GameObject obj = isStar ? starPool.Get() : obstaclePool.Get();

        obj.transform.position = pos;

        if (!isStar)
        {
            TrapColor trapColor = obj.GetComponent<TrapColor>();

            if (trapColor != null)
            {
                ColorType randomColor = (ColorType)Random.Range(0, 4);
                trapColor.SetColor(randomColor);
            }
        }
        
        var view = obj.GetComponent<CircleObjectView>();
        if (view != null)
        {
            view.Initialize(gameService);
        }
    }
}