using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



public class ButtonManager1 : MonoBehaviour
{

    string[] keycode = { "4", "5", "1", "10" };
    int keyindex;
    int incorrectNum;
    int incorrectAttempt;
    public AudioSource aud;
    public AudioClip incorrect;
    public AudioClip correct;
    public float delayTime;
    public GameObject shuttle;


    public bool incorrectOff;
    public bool correctOff;
    public bool activeOff;
    public bool countdownOff;
    public AudioClip transmission;
    public AudioClip transmission2;

    // Start is called before the first frame update
    void Start()
    {
        activeOff = false;
        countdownOff = false;
        keyindex = 0;
        aud = gameObject.GetComponent<AudioSource>();
     
    }
    public void CheckFirstNum( string buttonPressed )
    {
        

        print("key pressed=" + buttonPressed);
        print("checking for key" + keycode[keyindex]);
        print("key index=" + keyindex);

        if (buttonPressed == keycode[keyindex])
        {
            keyindex++;
            if (keycode[keyindex] == "10")
            {
                print("successful");
                aud.PlayOneShot(correct, 0.5f);
                shuttle.GetComponent<Animator>().SetTrigger("Move");
                
            }
        }
        else
        {
            
            print(delayTime);
            incorrectAttempt++;       
            if (incorrectAttempt == 3)
            {
                aud.PlayOneShot(incorrect, 2f);
                keyindex = 0;
             

            }
            if (incorrectAttempt == 6)
            {
                aud.PlayOneShot(incorrect, 2f);
                keyindex = 0;
        
            }
            if (incorrectAttempt == 9)
            {
                aud.PlayOneShot(incorrect, 2f);
                aud.PlayOneShot(transmission);
                StartCoroutine("Transmission");
            }

        }
    }
    public IEnumerator Transmission()
    {            
        yield return new WaitForSeconds(2);
        aud.PlayOneShot(transmission2, 2f);
        yield return new WaitForSeconds(6);
        StopAllCoroutines();
   
    }
}
