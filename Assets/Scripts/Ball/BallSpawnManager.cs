using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numberOfBalls;
    //public float spawnRadius;

    [SerializeField] private LayerMask ballLayer = LayerMask.GetMask("Ball");

    [SerializeField] float spawnRadius = 3f;
    private void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            SpawnBall();
        }
    }


    void SpawnBall()
    {
        Vector2 spawnPosition = Vector2.zero;
        do
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            spawnPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
        } while (Physics2D.OverlapCircle(spawnPosition, 0.5f, ballLayer));

        GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        BallMovement ballMovement = ball.GetComponent<BallMovement>();
        ballMovement.AddForceAtAngle();
    }


    //private void Awake()
    //{
    //    SpawnBalls();
    //}

    //private void SpawnBalls()
    //{
    //    for (int i = 0; i < numberOfBalls; i++)
    //    {
    //        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
    //        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    //    }
    //}
}
