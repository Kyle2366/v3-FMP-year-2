using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour
{

    public GameObject rF;
    public ParticleSystem gas;
    string[] keycode = { "4", "5", "1", "10" };
    int keyindex;
    int incorrectNum;
    int incorrectAttempt;
    public AudioSource aud;
    public AudioClip incorrect;
    public AudioClip correct;
    public AudioClip cough;
    public AudioClip active;
    public AudioClip countdown;
    public bool gasOn;
    public bool dead;
    public float delayTime;


    public bool incorrectOff;
    public bool correctOff;
    public bool activeOff;
    public bool countdownOff;

    public GameObject laserGate;
    // Start is called before the first frame update
    void Start()
    {
        activeOff = false;
        countdownOff = false;
        gasOn = false;
        keyindex = 0;
        aud = gameObject.GetComponent<AudioSource>();
        gas.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
       DeathCount();
       
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
                laserGate.SetActive(false);
                rF.GetComponent<RobotFriend>().keypadCode = true;
                StopAllCoroutines();
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
                rF.GetComponent<RobotFriend>().incorrectCode = true;

            }
            if (incorrectAttempt == 6)
            {
                aud.PlayOneShot(incorrect, 2f);
                keyindex = 0;
                rF.GetComponent<RobotFriend>().incorrectCode = true;
            }
            if (incorrectAttempt == 9)
            {  
                incorrectAttempt = 0;
                rF.GetComponent<RobotFriend>().incorrectCode = true;
                aud.PlayOneShot(incorrect);
             
         
                delayTime = 2f;
                gasOn = true;
                StartCoroutine("DeathCount");
            }

        }
    }
    public IEnumerator DeathCount()
    {         
        if (gasOn)
        {
            gasOn = false;
            gas.GetComponent<ParticleSystem>().Play();
            rF.GetComponent<RobotFriend>().gasOn = true;
            yield return new WaitForSeconds(10f);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
       
    }
   /* public void Reset()
    {
        if (dead && delayTime <= 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);

        } 
    } */

}
