using System;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private float _loseScoreValue = -30f;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.OnStartTouch += OnTouch;
    }

    private void OnTouch(Vector2 position, float time)
    {
        GameManager.Instance.AddScore(_loseScoreValue);
        GameManager.NewRandomMicrogame();
    }
}
