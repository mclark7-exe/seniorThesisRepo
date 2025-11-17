using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Sweep : MonoBehaviour
{
    private SwipeDetection _swipeDetection;
    [SerializeField]private string _direction = "";
    [SerializeField] private float _destination;
    [SerializeField] private float _startPosition;
    [SerializeField] private int _swipeThreshold = 10;
    private int _swipes = 0;
    [SerializeField]private float _speed;

    private void Start()
    {
        _swipeDetection = FindFirstObjectByType<SwipeDetection>();
        _swipeDetection.OnSwipe += Swipe;
    }


    private void Swipe(string direction)
    {
        if (_direction != direction && direction != "up" && direction != "down")
        {
            _direction = direction;
            _swipes++;
            
            if (_swipes >= _swipeThreshold)
            {
                Debug.Log("Sweep threshold reached");
            }
        }
    }

    private void Update()
    {
        if (_swipes <= _swipeThreshold)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, _startPosition + ((_destination / _swipeThreshold) * _swipes)), _speed * Time.deltaTime);
    }
    
    
}
