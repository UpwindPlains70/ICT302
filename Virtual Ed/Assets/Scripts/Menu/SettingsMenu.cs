using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer musicAudioMixer;
    public AudioMixer effectsAudioMixer;
    public AudioMixer voiceAudioMixer;

    public Slider musicSlider;
    public Slider effectsSlider;
    public Slider voiceSlider;

    private void Start()
    {
        
    }
    public void SetMusicVolume()
    {
        musicAudioMixer.SetFloat("volume", musicSlider.value);
    }
    
    public void SetEffectsVolume()
    {
        musicAudioMixer.SetFloat("volume", effectsSlider.value);
    }

    public void SetVoiceVolume()
    {
        voiceAudioMixer.SetFloat("volume", voiceSlider.value);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
