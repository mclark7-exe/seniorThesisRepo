using UnityEngine;
using TMPro;

public class CurtainCall : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    void Start()
    {
        int _score = (int)GameManager.GetScore();
        int _highScore = PlayerPrefs.GetInt("HighScore");

        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
        
        _scoreText.text = "Score: " + _score + "\nHigh Score: " + _highScore;
    }

}
