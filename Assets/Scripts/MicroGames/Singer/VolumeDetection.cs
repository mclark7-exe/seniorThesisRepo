using UnityEngine;
using UnityEngine.Android;

public class VolumeDetection : MonoBehaviour
{

    private string _microphoneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.Log("Microphone access denied.");
            Permission.RequestUserPermission(Permission.Microphone);
        }
        else Debug.Log(Microphone.devices);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
