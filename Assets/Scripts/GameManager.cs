using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool _lineMemorized = false;
    private static Line _memorizedLine = null;
    
    private static float _score = 0;
    private static float _audienceReaction = 50f;
    private const int _scoreMultiplier = 10;
    private static float _difficulty = 1;

    public static void AddScore(float score)
    {
        if (score > 0) _score += score * _scoreMultiplier;
        _audienceReaction += score;
        _audienceReaction = Mathf.Clamp(_audienceReaction, 0, 100);
    }
    
    
    public static float GetScore() { return _score; }
    public static float GetAudienceReaction() { return _audienceReaction; }
    public static bool IsLineMemorized() { return _lineMemorized; }
    public static void SetLineMemorized(bool value) { _lineMemorized = value; }
    public static Line GetMemorizedLine() { return _memorizedLine; }
    public static void SetMemorizedLine(Line value) { _memorizedLine = value; }
    public static float GetDifficulty() { return _difficulty; }

    private static bool _running = true;
    private void Awake()
    {
        GameManager[] managers = FindObjectsByType<GameManager>(FindObjectsSortMode.None);
        if (managers.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        
        if (_audienceReaction < 0)
        {
            _audienceReaction = 0;
            _running = false;
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
        else if (_running) 
        {
            _audienceReaction -= Time.deltaTime * _difficulty * 2;
        }
    }

    public static void NewRandomMicrogame()
    {
        int newMicrogame = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings - 1);
        while (newMicrogame == SceneManager.GetActiveScene().buildIndex)
        {
            newMicrogame = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings - 1);
        }
        
        _difficulty += 0.1f;
        SceneManager.LoadScene(newMicrogame);
    }

    public static void RestartGame()
    {
        _score = 0;
        _running = true;
        _audienceReaction = 50f;
        NewRandomMicrogame();
    }
}
