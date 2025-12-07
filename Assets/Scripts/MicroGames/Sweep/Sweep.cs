using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Sweep : MonoBehaviour
{
    private SwipeDetection _swipeDetection;
    [SerializeField]private string _direction = "";
    
    [SerializeField] private float _destination;
    [SerializeField] private float _startPosition;
    [SerializeField] private int _swipeThreshold = 8;
    private int _swipes = 0;
    [SerializeField]private float _speed;
    [SerializeField] private int _scoreValue = 30;
    private float _difficulty;

    private void Start()
    {
        _swipeDetection = FindFirstObjectByType<SwipeDetection>();
        _swipeDetection.OnSwipe += Swipe;
        _difficulty = GameManager.GetDifficulty();
        _swipeThreshold += (int)_difficulty * 2;
    }


    private void Swipe(string direction)
    {
        if (_direction != direction && direction != "up" && direction != "down")
        {
            _direction = direction;
            _swipes++;
            
            if (_swipes >= _swipeThreshold)
            {
                GameManager.AddScore(_scoreValue);
                GameManager.NewRandomMicrogame();
            }
        }
    }

    private void Update()
    {
        int direction = _direction == "left" ? -2 : _direction == "right" ? 2 : 0;
        if (_swipes <= _swipeThreshold)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(direction, _startPosition + ((_destination / _swipeThreshold) * _swipes)), _speed * Time.deltaTime);
    }
    
    
}
