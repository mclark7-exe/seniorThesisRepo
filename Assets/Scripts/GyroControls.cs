using System;
using UnityEngine;

public class GyroControls : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _gyro;
    
    private Camera _mainCamera;
    private float _cameraWidth;
    
    private Vector3 _newPosition;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _radius = 1;

    private void Start()
    {
        _gyroEnabled = EnableGyro();
        _mainCamera = Camera.main;
        _cameraWidth = _mainCamera.orthographicSize*_mainCamera.aspect;
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;
            Debug.Log("Gyro enabled");
            return true;
        }
        Debug.Log("Gyro not found :(");
        return false;
    }
    
    private void FixedUpdate()
    {
        if (_gyroEnabled)
        {
            _newPosition = transform.position + new Vector3(_gyro.rotationRateUnbiased.y * -1, _gyro.rotationRateUnbiased.x, 0) * _speed;
            if (Math.Abs(_newPosition.x) >= _cameraWidth - _radius) _newPosition.x = transform.position.x; 
            if (Math.Abs(_newPosition.y) >= _mainCamera.orthographicSize - _radius) _newPosition.y =  transform.position.y;    
            transform.position = _newPosition;
        }
    }
}
