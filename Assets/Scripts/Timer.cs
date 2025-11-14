using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    float elapsedTime = 0f;
    public delegate void TimerDelegate();
    public event TimerDelegate OnTimerEnd;
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _timeLimit && OnTimerEnd != null)
        {
            OnTimerEnd();
        }
    }

    public void SetTimeLimit(float timeLimit)
    {
        _timeLimit = timeLimit;
    }
}
