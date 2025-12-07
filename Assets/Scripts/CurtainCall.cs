using System;
using UnityEngine;
using TMPro;

public class CurtainCall : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = (int)GameManager.GetScore();
    private int _highScore = PlayerPrefs.GetInt("HighScore");
    void Start()
    {
        

        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
        
        
    }


    private void Update()
    {
        _scoreText.text = "Score: " + _score + "\nHigh Score: " + _highScore;
    }
}
