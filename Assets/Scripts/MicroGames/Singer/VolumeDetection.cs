using System;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class VolumeDetection : MonoBehaviour
{

    private string _microphoneName;
    private AudioClip _microphoneClip;
    private int _sampleWindow = 64;
    [SerializeField] private GameObject _circle;
    [SerializeField] private float _volumeMultiplier = 1.0f;
    [SerializeField] private float _volumeThreshold = 3f;
    [SerializeField] private float _clipLengthThreshold = 3f;
    private int _clipsAboveThreshold = 0;
    [SerializeField] private int _scoreValue = -30;
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.Log("Microphone access denied.");
            Permission.RequestUserPermission(Permission.Microphone);
        }

        if (Microphone.devices.Length != 0)
        {
            Debug.Log(Microphone.devices.Length + " microphone detected.");
            _microphoneName = Microphone.devices[0];
            _microphoneClip = Microphone.Start(_microphoneName, true, 10, AudioSettings.outputSampleRate);
        }
        else
            Debug.Log("No microphone detected.");
        
    }

    private float AudioClipVolume()
    {
        int startPosition = Microphone.GetPosition(Microphone.devices[0]) - _sampleWindow;
        float[] waveData = new float[_sampleWindow];
        _microphoneClip.GetData(waveData, startPosition);

        float totalVolume = 0;

        foreach (float volume in waveData)
        {
            totalVolume += Mathf.Abs(volume);
        }
        
        return totalVolume / _sampleWindow;
    }

    private void Update()
    {
        float volume = AudioClipVolume() * _volumeMultiplier;
        _circle.transform.localScale = new Vector3(volume, volume, 1);
        if (volume * _volumeMultiplier > _volumeThreshold) _clipsAboveThreshold++;
        else _clipsAboveThreshold = 0;
        if (_clipsAboveThreshold >= _clipLengthThreshold)
        {
            GameManager.AddScore(_scoreValue);
            GameManager.NewRandomMicrogame();
        }
    }
}
