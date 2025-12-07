using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    float elapsedTime = 0f;
    public delegate void TimerDelegate();
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _timeLimit)
        {
            GameManager.NewRandomMicrogame();
        }
    }

    public void SetTimeLimit(float timeLimit)
    {
        _timeLimit = timeLimit;
    }
}
