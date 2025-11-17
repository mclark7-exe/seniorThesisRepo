using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugNextScene : MonoBehaviour
{
    [SerializeField] private bool _debug = false;

    private void Awake()
    {
        DebugNextScene[] managers = FindObjectsByType<DebugNextScene>(FindObjectsSortMode.None);
        if (managers.Length == 1 && _debug) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);
        
    }

    public void NextScene()
    {
        Debug.Log("Next Scene");
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Returning to Memorize Line");
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}