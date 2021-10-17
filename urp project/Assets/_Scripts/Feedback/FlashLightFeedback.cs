using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightFeedback : Feedback
{
    [SerializeField] private Light2D lightTarget;
    [SerializeField] private float lightOnDelay = 0.01f;
    [SerializeField] private float lightOffDelay = 0.01f;
    [SerializeField] private bool defaultState = false;

    public override void CreateFeedback()
    {
        StartCoroutine(ToggleLight(lightOnDelay, true, () => StartCoroutine(ToggleLight(lightOffDelay, false))));
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        lightTarget.enabled = defaultState;
    }

    private IEnumerator ToggleLight(float time, bool result, Action finishCallback = null)
    {
        yield return new WaitForSeconds(time);
        lightTarget.enabled = result;
        finishCallback?.Invoke();
    }
}