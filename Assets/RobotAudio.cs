using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RobotSpeech
{

    intro,
    exit,
    fireExtinguisherSpeech,
    unHappySpeech,
    idle,
    transmission,




}

public class RobotAudio : MonoBehaviour
{

    public float delayTime;
    public AudioSource aud;
    public AudioClip fireExtinguisher;
    public AudioClip unHappy;
    public AudioClip exit;
    public AudioClip intro;
    public AudioClip intro2;
    public AudioClip transmission1;
    public AudioClip transmission2;
    RobotSpeech rS;

    public bool stop;
    public bool cardInsert;
    // Start is called before the first frame update
    void Start()
    {
        cardInsert = false;
        stop = false;
        rS = RobotSpeech.intro;
        delayTime = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }

    public void DoLogic()
    {
        if (rS == RobotSpeech.intro)
        {
            delayTime -= Time.deltaTime;
            IntroState();
        }
        if (rS == RobotSpeech.idle)
        {
            if (cardInsert)
            {
                rS = RobotSpeech.transmission;
            }
        }
        if (rS == RobotSpeech.transmission)
        {
            TransmissionState();
        }
    }
    

    public void IntroState()
    {
        if (delayTime > 0 && !stop)
        {
            aud.PlayOneShot(intro, 2f);
            stop = true;
        }
        if (delayTime <= 0)
        {
            aud.PlayOneShot(intro2);
            rS = RobotSpeech.idle;
        }

    }
    public void TransmissionState()
    {
        aud.PlayOneShot(transmission1);
    }
}
