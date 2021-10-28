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

    private void Start()
    {
        
    }
    public void SetMusicVolume(float sliderVal)
    {
        musicAudioMixer.SetFloat("MainMixer", Mathf.Log10(sliderVal) * 20);
    }
    
    public void SetEffectsVolume(float sliderVal)
    {
        musicAudioMixer.SetFloat("SoundEffectMixer", Mathf.Log10(sliderVal) * 20);
    }

    public void SetVoiceVolume(float sliderVal)
    {
        voiceAudioMixer.SetFloat("VoiceMixer", Mathf.Log10(sliderVal) * 20);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
