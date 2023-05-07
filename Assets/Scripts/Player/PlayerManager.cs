using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;

    private void Awake()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            ReplayLevel();
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
