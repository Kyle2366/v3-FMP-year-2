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
    hint,




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
    public AudioClip cardHint;
    RobotSpeech rS;

    public bool stop;
    public bool cardInsert;

    public bool speaking;
    public bool hint;
    public bool timerSet;
    public bool fireHint;
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
   
        if (cardInsert)
        {
            print("Card has been inserted");
        }
        if (!cardInsert)
        {
            print("Card has not been inserted");
        }
    }

    public void DoLogic()
    {
        if (rS == RobotSpeech.intro)
        {
            print("Intro");
            delayTime -= Time.deltaTime;
            IntroState();
        }
        if (rS == RobotSpeech.idle)
        {
            print("idle");
            IdleState();
            
        }
        if (rS == RobotSpeech.transmission)
        {
            print("Transmission");
            StartCoroutine(TransmissionState());
        }
        if (rS == RobotSpeech.fireExtinguisherSpeech)
        {
            FireExtinguisherSpeechState();
        }
    }
    
    public void FireExtinguisherSpeechState()
    {
        if (!fireHint)
        {
            aud.PlayOneShot(fireExtinguisher);
            fireHint = true;
        }
        
    }
    public void IdleState()
    {
        delayTime -= Time.deltaTime;
        if (delayTime <= 0 && !timerSet)
        {
            delayTime = 5f;
            timerSet = true;
        }
        
       
        print("Idle");
        if (cardInsert)
        {
            stop = false;
            rS = RobotSpeech.transmission;
        }
        else
        {
            if (!hint && delayTime <=0 )
            {
                hint = true;
                aud.PlayOneShot(cardHint, 2f);
            }
            
        }
    }
    public void IntroState()
    {
   
        if (delayTime > 0 && !stop)
        {
            aud.PlayOneShot(intro, 2f);
            stop = true;
        }
        if (delayTime <= 0 && !speaking)
        {
            aud.PlayOneShot(intro2);
            speaking = true;
            rS = RobotSpeech.idle;
            
        }

    }
    public IEnumerator TransmissionState()
    {
        if (rS == RobotSpeech.transmission && !stop)
        {
            stop = true;
            aud.PlayOneShot(transmission1 ,2f);
            yield return new WaitForSeconds(2f);
            aud.PlayOneShot(transmission2 ,2f);
            yield return new WaitForSeconds(5f);
            aud.PlayOneShot(unHappy, 2f);
            yield return new WaitForSeconds(5f);
            rS = RobotSpeech.fireExtinguisherSpeech;
            StopAllCoroutines();
        }
    }
}
