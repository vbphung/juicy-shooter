using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    [SerializeField] private List<Feedback> feedbackToPlay;

    public void PlayFeedback()
    {
        FinishFeedback();
        foreach (Feedback feedback in feedbackToPlay)
            feedback.CreateFeedback();
    }

    private void FinishFeedback()
    {
        foreach (Feedback feedback in feedbackToPlay)
            feedback.CompletePreviousFeedback();
    }
}