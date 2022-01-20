using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip deadClip;
    [SerializeField] private AudioClip voiceLineClip;

    public void PlayHitSound()
    {
        PlayWithVariablePitch(hitClip);
    }

    public void PlayDeadSound()
    {
        PlayClip(deadClip);
    }

    public void PlayVoiceSound()
    {
        PlayWithVariablePitch(voiceLineClip);
    }
}