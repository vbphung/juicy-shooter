using UnityEngine;

using DG.Tweening;

public class ShakeFeedback : Feedback
{
    [SerializeField] private GameObject shakeObject;
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float strength = 1;
    [SerializeField] private float randomness = 90;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private bool snapping = false;
    [SerializeField] private bool fadeOut = true;

    public override void CompletePreviousFeedback()
    {
        shakeObject.transform.DOComplete();
    }

    public override void CreateFeedback()
    {
        CompletePreviousFeedback();
        shakeObject.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}