using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _remaining_time = 0.0f;
    private bool _running = false;

    private float _time = 0.0f;
    public float time { get => _time; set => _time = value; }

    public event Action onTimerFinished;

    public static Timer NewTimer(GameObject parent, float t, Action callback)
    {
        Timer toReturn = parent.AddComponent<Timer>();
        toReturn.time = t;
        toReturn.onTimerFinished += callback;
        return toReturn;
    }


    void Update()
    {
        if (_running && _remaining_time > 0f)
        {
            _remaining_time -= Time.deltaTime;
            if (_remaining_time <= 0.0f)
            {
                _running = false;
                _remaining_time = 0.0f;
                onTimerFinished?.Invoke();
            }
        }
    }


    public void StartTimer()
    {
        _running = true;
        _remaining_time = time;
    }


    public void StopTimer()
    {
        _running = false;
        _remaining_time = 0.0f;
    }


    public void PauseTimer()
    {
        _running = false;
    }


    public void ResumeTimer()
    {
        // only resume if we have time remaining.
        _running = _remaining_time > 0.0f;
    }


    public bool IsRunning()
    {
        return _running;
    }


    public float GetRemainingTime()
    {
        return _remaining_time;
    }
}
