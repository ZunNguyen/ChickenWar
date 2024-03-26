using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ErshenMonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource sfxSource;

    [Header("---Music Source---")]
    public AudioClip musicMain;
    public AudioClip musicBattle;
    public AudioClip effectEarnGold;
    public AudioClip effectSpawnButton;
    public AudioClip effectShooting;
    public AudioClip effectDelete;
    public AudioClip effectBoom;
    public AudioClip effectShieldCollision;
    public AudioClip effectUpgradeNewChickenHigher;
    public AudioClip effectWinWave;
    public AudioClip effectGameOver;
    public AudioClip effectSpawnError;
    public AudioClip effectUpgradeChicken;
    public AudioClip effectClick;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadMusicSource();
        LoadSFXSource();
    }

    protected virtual void LoadMusicSource()
    {
        if (musicSource != null) return;
        musicSource = transform.Find("Music Source").GetComponent<AudioSource>();
    }

    protected virtual void LoadSFXSource()
    {
        if (sfxSource != null) return;
        sfxSource = transform.Find("SFX Source").GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic(musicMain);
    }

    public virtual void PlayMusic(AudioClip clipName)
    {
        musicSource.clip = clipName;
        musicSource.Play();
    }

    public virtual void PlaySFX(AudioClip clipName)
    {
        sfxSource.PlayOneShot(clipName);
    }

    public virtual void PauseMusic(AudioClip clipName)
    {
        musicSource.clip = clipName;
        musicSource.Pause();
    }
}
