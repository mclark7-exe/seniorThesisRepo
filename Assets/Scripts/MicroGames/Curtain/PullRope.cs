using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PullRope : MonoBehaviour
{
    private InputManager _inputManager;
    private bool _fingerDown;
    private Vector2 _startPosition;
    private RectTransform _rectTransform;
    [SerializeField] private GameObject _curtain;
    [SerializeField] private float _curtainSpeed = 0.2f;
    [SerializeField] private float _curtainTargetHeight = 5;
    [SerializeField] private float _scoreValue = 25;
    
    private Transform _curtainTransform;
    
    private void Start()
    {
        _inputManager = FindFirstObjectByType<InputManager>();
        _rectTransform = GetComponent<RectTransform>();
        _curtainTransform = _curtain.GetComponent<Transform>();
        _inputManager.OnStartTouch += PullStart;
        _inputManager.OnEndTouch += PullEnd;
    }
    
    private void OnEnable()
    {
        _inputManager.OnStartTouch += PullStart;
        _inputManager.OnEndTouch += PullEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= PullStart;
        _inputManager.OnEndTouch -= PullEnd;
    }

    private void PullStart(Vector2 position, float time)
    {
        Debug.Log(position);
        Debug.Log(_rectTransform.rect);
        if (_rectTransform.rect.Contains(position))
        {
            _fingerDown = true;
            _startPosition = position;
            Debug.Log("Pull start");
        }
    }

    private void PullEnd(Vector2 position, float time)
    {
        _fingerDown = false;
    }

    private void FixedUpdate()
    {
        if (_fingerDown)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(_inputManager.TouchPosition);
            Vector2 delta = touchPosition - _startPosition;
            transform.Translate(0, delta.y, 0);
            _startPosition = touchPosition;
            _curtainTransform.Translate(0, delta.y * _curtainSpeed * -1, 0);
        }
        Loop();
        Curtain();
    }
    
    private void Loop()
    {
        if (_rectTransform.position.y > 10)
        {
            transform.Translate(0, -10, 0);
        }

        if (_rectTransform.position.y < -10)
        {
            transform.Translate(0, 10, 0);
        }
    }

    private void Curtain()
    {
        if (_curtainTransform.position.y < 0)
        {
            _curtainTransform.position = new Vector3(0,0,1);
        }
        if (_curtainTransform.position.y > _curtainTargetHeight)
        {
            GameManager.Instance.AddScore(_scoreValue);
            GameManager.NewRandomMicrogame();
        }
    }

}
