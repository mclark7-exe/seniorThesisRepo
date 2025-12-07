using System;
using UnityEngine;

public class GyroThreshold : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _gyro;
    [SerializeField] private float _gyroThreshold = 1f;
    [SerializeField] private float _loseScoreValue = -30f;
    [SerializeField] private float _passiveScoreValue = 6f;

    private void Start()
    {
        _gyroEnabled = EnableGyro();
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
    
    private void Update()
    {
        if (_gyroEnabled)
        {
            if (_gyro.rotationRateUnbiased.y > _gyroThreshold || _gyro.rotationRateUnbiased.x > _gyroThreshold)
            {
                GameManager.AddScore(_loseScoreValue);
                GameManager.NewRandomMicrogame();
            }
            else
            {
                GameManager.AddScore(_passiveScoreValue * Time.deltaTime);
            }
        }
    }
}