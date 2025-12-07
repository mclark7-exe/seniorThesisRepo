using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private int _loseScoreValue = -30;
    [SerializeField] private float _gracePeriod;
    private float _difficulty;
    private bool _waiting = true;
    private void Awake()
    {
        _difficulty = GameManager.GetDifficulty();
        _inputManager = GetComponent<InputManager>();
        StartCoroutine(Wait());

    }

    private void OnTouch(Vector2 position, float time)
    {
        GameManager.AddScore(_loseScoreValue);
        GameManager.NewRandomMicrogame();
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_gracePeriod / _difficulty);
        _inputManager.OnStartTouch += OnTouch;
    }
}
