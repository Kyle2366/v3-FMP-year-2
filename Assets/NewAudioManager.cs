using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NewAudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SetSound(float soundLevel)
    {
       masterMixer.SetFloat("musicVol", soundLevel);
        print(soundLevel);
    }
}
