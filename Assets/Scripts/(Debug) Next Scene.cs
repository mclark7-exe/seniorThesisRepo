using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugNextScene : MonoBehaviour
{
    [SerializeField] private bool _debug = false;

    private void Start()
    {
        DebugNextScene[] managers = FindObjectsByType<DebugNextScene>(FindObjectsSortMode.None);
        if (managers.Length == 1 && _debug) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}