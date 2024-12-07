

using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundService
{
    private AudioSource sFXAudioSource;
    private AudioSource bgAudioSource;
    private Sound[] SoundsCollection;
    
    public SoundService(AudioSource sFXAudioSource, AudioSource bgAudioSource, Sound[] soundsCollection)
    {
        this.SoundsCollection = soundsCollection;
        this.sFXAudioSource = sFXAudioSource;
        this.bgAudioSource = bgAudioSource;
    }


    public void PlaySFXSound(SoundType soundType)
    {
        AudioClip clip= GetAudioClip(soundType);
        if(clip != null)
        {
            sFXAudioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetAudioClip(SoundType soundType)
    {
        Sound sound = Array.Find(SoundsCollection, i => i.soundType == soundType);
        if(sound != null)
        {
            return sound.clip;
        }
        return null;
    }

    public void PlayBackgroundSound(SoundType soundType)
    {
        AudioClip clip = GetAudioClip(soundType);
        bgAudioSource.clip= clip;
        bgAudioSource.Play();
    }

}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip clip;
}


public enum SoundType
{
    NONE,
    RELOADING,
    SMG_SHOOT,
    AR_SHOOT,
    PISTOL_SHOOT,
    MG_SHOOT,
    WEAPON_CHANGE,
    RELOAD_COMPLETE
}