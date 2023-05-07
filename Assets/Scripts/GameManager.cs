using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform centerPoint;
    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private float ballRadius;
    [SerializeField] private int numOfBalls;

    private void Start()
    {
        SpawnBalls();
        Time.timeScale = 0f; // Oyunu durdur
    }

    private void SpawnBalls()
    {
        for (int i = 0; i < numOfBalls; i++)
        {
            Vector2 spawnPoint = GetRandomSpawnPoint();
            Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
        }
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
        Vector2 spawnPoint = new Vector2(centerPoint.position.x, centerPoint.position.y);

        while (Physics2D.OverlapCircle(spawnPoint, ballRadius, ballLayer))
        {
            randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
            spawnPoint = new Vector2(centerPoint.position.x, centerPoint.position.y);
        }

        return spawnPoint;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týklandý mý kontrol eder
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Diðer objelerin hareketini baþlatýr
    }
}
