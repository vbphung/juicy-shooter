using System;
using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
    }

    public void ModifyTimeScale(float endTime,float waitTime,Action onCompleteCallback = null)
    {
        StartCoroutine(TimeScale(endTime, waitTime, onCompleteCallback));
    }

    private IEnumerator TimeScale(float endTime, float waitTime, Action onCompleteCallback = null)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = endTime;
        onCompleteCallback?.Invoke();
    }
}