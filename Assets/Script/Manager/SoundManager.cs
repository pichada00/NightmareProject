using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //[SerializeField] private AudioClip[] audioClips;
    [SerializeField] private SoundClip[] soundClips;
    [SerializeField] private AudioSource audioSource;

    public static SoundManager Instance { get; private set; }

    public enum Sound
    {
        BGM,
        PlayerWalked,
        Hit,
        Pickup,
        open,
        close,
        laugh
    }

    [Serializable]
    public struct SoundClip
    {
        public Sound sound;
        public AudioClip audioClip;
        [Range(0,1)]public float soundVolume;
    }

    private void Awake()
    {
        Debug.Assert(soundClips != null && soundClips.Length != 0, "sound clips need to be setup");
        Debug.Assert(audioSource != null, "audioSource cannot be null");

        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void Play(AudioSource audioSource,Sound sound)
    {
        var soundClip = GetSoundClip(sound);
        audioSource.clip = soundClip.audioClip;
        audioSource.volume = soundClip.soundVolume;
        audioSource.Play();
    }

    
    public void PlayBGM()
    {
        audioSource.loop = true;
        Play(audioSource, Sound.BGM);
    }

    private SoundClip GetSoundClip(Sound sound)
    {
        foreach (var soundClip in soundClips)
        {
            if (soundClip.sound == sound)
            {
                return soundClip;
            }
        }

        return default(SoundClip);
    }




}
