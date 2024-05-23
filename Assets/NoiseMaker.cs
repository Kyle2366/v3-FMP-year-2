using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{

    public AudioSource aud;
    public AudioClip correct;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCorrect()
    {
        aud.PlayOneShot(correct, 1f);
    }
}
