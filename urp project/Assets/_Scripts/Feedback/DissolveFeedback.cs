using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DissolveFeedback : Feedback
{
    [SerializeField] private SpriteRenderer modelRenderer;
    [SerializeField] private float dissolveDuration;
    [SerializeField] public UnityEvent deathCallback;

    public override void CompletePreviousFeedback()
    {
        modelRenderer.DOComplete();
        modelRenderer.material.DOComplete();
    }

    public override void CreateFeedback()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(modelRenderer.material.DOFloat(0, "_Dissolve", dissolveDuration));

        if (deathCallback != null)
            sequence.AppendCallback(() => deathCallback.Invoke());
    }
}