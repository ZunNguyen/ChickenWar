using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingVolume : CanvasAbstract
{
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider sfxSlider;

    public virtual void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public virtual void SetSfxVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
