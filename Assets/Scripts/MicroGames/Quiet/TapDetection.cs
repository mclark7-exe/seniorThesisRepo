using System;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
    private InputManager _inputManager;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _inputManager.OnStartTouch += OnTouch;
    }

    private void OnTouch(Vector2 position, float time)
    {
        Debug.Log("Touch Detected. Quiet on set!");
    }
}
