using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{

    static SoundManager soundManagerInstance;
    public static SoundManager SoundManagerInstance
    {
        get
        {
            return soundManagerInstance;
        }
    }

    [SerializeField]
    AudioSource musicAudioSource, effectsAudioSource;

    [SerializeField]
    SoundData[] soundsToPlay;

    private void Awake()
    {
        if(soundManagerInstance == null)
        {
            soundManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(SoundType.BackgroundMusic);
    }

    public void PlaySoundEffects(SoundType typeOfSoundToPlay)
    {
        foreach(SoundData soundData in soundsToPlay)
        {
            if(soundData.type == typeOfSoundToPlay)
            {
                effectsAudioSource.PlayOneShot(soundData.soundClip);
                break;
            }
        }
    }

    public void PlayMusic(SoundType typeOfSoundToPlay)
    {
        foreach (SoundData soundData in soundsToPlay)
        {
            if (soundData.type == typeOfSoundToPlay)
            {
                if(musicAudioSource.isPlaying)
                {
                    musicAudioSource.Stop();
                }
                musicAudioSource.clip = soundData.soundClip;
                musicAudioSource.Play();
                break;
            }
        }
    }
}

public enum SoundType
{
    ButtonClick,
    PlayerMove,
    PlayerJump,
    BackgroundMusic,
    ItemPickup,
    PlayerDeth,
    LevelComplete,
    PlayerHurt,
    EnemyDie,
    PlayerAttack
}

[Serializable]
public class SoundData
{
    public SoundType type;
    public AudioClip soundClip;
}
