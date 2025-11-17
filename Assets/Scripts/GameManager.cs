using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private bool _lineMemorized = false;
    
    public bool IsLineMemorized() { return _lineMemorized; }
    public void SetLineMemorized(bool value) { _lineMemorized = value; }

    private void Awake()
    {
        GameManager[] managers = FindObjectsByType<GameManager>(FindObjectsSortMode.None);
        if (managers.Length == 1) DontDestroyOnLoad(gameObject);
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
}
