using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip outShootClip;

    public void PlayShootSound()
    {
        PlayClip(shootClip);
    }

    public void PlayNoBulletSound()
    {
        PlayClip(outShootClip);
    }
}