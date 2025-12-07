using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GyroThreshold : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _gyro;
    private float _difficulty;
    private bool _waiting = true;
    [SerializeField]private float _gracePeriod;
    [SerializeField] private float _gyroThreshold = 1f;
    [SerializeField] private float _loseScoreValue = -30f;
    [SerializeField] private float _passiveScoreValue = 6f;

    private void Start()
    {
        _gyroEnabled = EnableGyro();
        _difficulty = GameManager.GetDifficulty();
        StartCoroutine(Wait());
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
        if (_gyroEnabled && !_waiting)
        {
            if (_gyro.rotationRateUnbiased.y > _gyroThreshold || _gyro.rotationRateUnbiased.x > _gyroThreshold)
            {
                GameManager.AddScore(_loseScoreValue);
                GameManager.NewRandomMicrogame();
            }
            else
            {
                GameManager.AddScore((_passiveScoreValue + (_difficulty * 2)) * Time.deltaTime);
            }
        }
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_gracePeriod / _difficulty);
        _waiting = false;
    }
}