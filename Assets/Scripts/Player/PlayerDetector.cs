using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerDetector : MonoBehaviour
{

    [SerializeField] private float _scoreAmount, _scoreIncreasedPerSecond;
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;
    private void Start()
    {
        _scoreAmount = 0;;
        UpdateHighScoreText();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.attachedRigidbody.transform.localScale += new Vector3(0.005f, 0.005f, 0);
        }

        if (collision.transform.tag == "Enemy")
        {
            scoreText.text = "Oxytocin: " + (int)_scoreAmount;
            _scoreAmount += _scoreIncreasedPerSecond * Time.deltaTime;

            CheckHighScore();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Penalty")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

    void CheckHighScore()
    {
        if (_scoreAmount > PlayerPrefs.GetFloat("Highest Oxytocin Score", 0))
        {
            PlayerPrefs.SetFloat("Highest Oxytocin Score", _scoreAmount);
            
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"Highest Oxytocin Score: {PlayerPrefs.GetFloat("Highest Oxytocin Score", 0)}";
    }

}
