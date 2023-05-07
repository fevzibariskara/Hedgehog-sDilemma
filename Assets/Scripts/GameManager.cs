using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ...

    private void Start()
    {
        Time.timeScale = 0f; // Diðer objelerin hareketini durdurur

        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(1f); // 1 saniye bekler

        Time.timeScale = 1f; // Diðer objelerin hareketini tekrar baþlatýr
    }

    // ...
}
