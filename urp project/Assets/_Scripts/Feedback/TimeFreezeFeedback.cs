using System.Collections;
using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField] private float freezeTimeDelay;
    [SerializeField] private float unfreezeTimeDelay;
    [SerializeField] [Range(0, 1)] private float freezeTime;

    public override void CompletePreviousFeedback()
    {
        if (TimeController.instance != null)
            TimeController.instance.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        TimeController.instance.ModifyTimeScale(freezeTime, freezeTimeDelay, () => TimeController.instance.ModifyTimeScale(1, unfreezeTimeDelay));
    }
}