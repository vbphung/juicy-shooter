using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour
{
    [SerializeField] protected float pitchRandomness = 0.05f;

    protected AudioSource audioSource;
    protected float basePitch;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    protected void PlayWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}