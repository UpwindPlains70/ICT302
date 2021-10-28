using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManagerNarration : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup VoiceMixer;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = VoiceMixer;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
   

        }
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();


    }
}
