using System;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private int _loseScoreValue = -30;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.OnStartTouch += OnTouch;
    }

    private void OnTouch(Vector2 position, float time)
    {
        GameManager.AddScore(_loseScoreValue);
        GameManager.NewRandomMicrogame();
    }
}
