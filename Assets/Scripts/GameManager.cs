using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private bool _lineMemorized = false;
    private Line _memorizedLine = null;
    
    private float _score = 0f;
    private float _audienceReaction = 50f;
    [SerializeField] private float _scoreMultiplier = 10f;
    [SerializeField] private float _audienceReactionDecay = 1f;

    public void AddScore(float score)
    {
        if (score > 0) _score += score * _scoreMultiplier;
        _audienceReaction += score;
        _audienceReaction = Mathf.Clamp(_audienceReaction, 0, 100);
    }
    
    
    public float GetScore() { return _score; }
    public float GetAudienceReaction() { return _audienceReaction; }
    public bool IsLineMemorized() { return _lineMemorized; }
    public void SetLineMemorized(bool value) { _lineMemorized = value; }
    public Line GetMemorizedLine() { return _memorizedLine; }
    public void SetMemorizedLine(Line value) { _memorizedLine = value; }
    
    public static GameManager Instance;

    private void Awake()
    {
        GameManager[] managers = FindObjectsByType<GameManager>(FindObjectsSortMode.None);
        if (managers.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        _audienceReaction -= Time.deltaTime * _audienceReactionDecay;
        Debug.Log("Audience Reaction: " + _audienceReaction);
        Debug.Log("Score: " + _score);
    }

    public static void NewRandomMicrogame()
    {
        int newMicrogame = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings - 1);
        while (newMicrogame == SceneManager.GetActiveScene().buildIndex)
        {
            newMicrogame = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings - 1);
        }
        
        SceneManager.LoadScene(newMicrogame);
    }
}
