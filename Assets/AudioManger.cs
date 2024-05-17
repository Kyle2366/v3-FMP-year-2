using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;


public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;

    public Sound[] sounds;

    private void Start()
    {
       
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);

        if (s == null)
        {
            print("Sound " + name + " not found");
            return;
        }
        s.source.Play();
    }

}
