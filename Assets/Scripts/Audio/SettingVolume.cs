using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingVolume : CanvasAbstract
{
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider sfxSlider;
    public float volumeMusic;
    public float volumeSFX;

    private void Start()
    {
        LoadBegin();
    }

    protected virtual void LoadBegin()
    {
        musicSlider.value = volumeMusic;
        audioMixer.SetFloat("Music", Mathf.Log10(volumeMusic) * 20);
        sfxSlider.value = volumeSFX;
        audioMixer.SetFloat("SFX", Mathf.Log10(volumeSFX) * 20);
    }

    public virtual void SetMusicVolume()
    {
        volumeMusic = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volumeMusic) * 20);
    }

    public virtual void SetSfxVolume()
    {
        volumeSFX = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volumeSFX) * 20);
    }
}
