using UnityEngine;

public class AgentStepAudio : AudioPlayer
{
    [SerializeField] private AudioClip stepClip;

    public void PlayStepSound()
    {
        PlayWithVariablePitch(stepClip);
    }
}