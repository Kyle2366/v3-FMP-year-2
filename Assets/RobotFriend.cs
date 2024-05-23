using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum robotStates
{
    moving,
    speech1,
    speech2,
    speech3,
    speech4,
    idle,
    hint,
    scan,
    hurt,
    nextScene,
}

public class RobotFriend : MonoBehaviour
{

    public ParticleSystem gas;
    robotStates rS;
    public AudioSource aud;
    public AudioClip opening;
    public AudioClip scan;
    public AudioClip speech2;
    public AudioClip speech3;
    public AudioClip speech4;
    public AudioClip speech5;
    public AudioClip cough;
    public AudioClip countdown;
    public GameObject friend;
    public Transform player;
    public GameObject robotArm;
    [Header("MovePoints")]
    public GameObject movePoint1;
    public GameObject movePoint2;
    public GameObject movePoint3;

    public Animator anim;
    public bool timerActive;

    public NavMeshAgent agent;
    public Vector3 destination;
    public float minDistance = 1f;

    public bool countDown;
    public bool scanning;
    public bool canMove;
    public bool canScan;
    public bool speechOver;
    public bool scanComplete;
    public bool speaking;
    public bool keypadCode;
    public bool incorrectCode;
    public bool gasOn;
    public bool speech3Off;

    float delayTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        speech3Off = false;
        gasOn = false;
        gas.Stop();
        incorrectCode = false;
        keypadCode = false;
        scanning = false;
        speaking = false;
        countDown = false;
        timerActive = false;
        canScan = false;

        
        //set up speech1 state
        rS = robotStates.speech1;
        delayTimer = 36;
        speaking = true;
        print("Opening Speech");
        aud.PlayOneShot(opening);



        scanComplete = false;
        speechOver = false;
        aud = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }
    public void DoLogic()
    {
        if (rS == robotStates.idle)
        {
            print("IDLE");
            MoveState();
         
        }
        if (rS == robotStates.speech2)
        {
            Speech2State();
        }
        if (rS == robotStates.speech1)
        {
            print(" STATE SPEECH 1");
            Speech1State();
            //StartCoroutine(Timer());
        }
        if (rS == robotStates.scan)
        {
            ScanState();
        }
        if (rS == robotStates.nextScene)
        {
            NextSceneState();
        }
    }

    public void MoveState()
    {
        if (canMove)
        {
            friend.GetComponent<NavMeshAgent>().speed = 2;
            print("moving");
            transform.LookAt(player);
            destination = movePoint1.transform.position;
            agent.destination = destination;
            if (Vector3.Distance(friend.transform.position, destination) < minDistance)
            {
                destination = movePoint2.transform.position;
            }
        }
    }
    public void Speech1State()
    {
        delayTimer -= Time.deltaTime;
        if( delayTimer < 0)
        {
            print("speech over");
            speechOver = true;
            canScan = true;

            // set up the Scan state
            rS = robotStates.scan;
        }
    }

    public void Speech2State()
    {
            if (gasOn)
            {
            aud.PlayOneShot(cough, .5f);
            aud.PlayOneShot(countdown);
            gasOn = false;
            }

            print("Entering keypad check");        
            //checking for correct keypad input
            if (keypadCode)
            {
                robotArm.GetComponent<Animator>().SetTrigger("reset");
                rS = robotStates.nextScene;
                aud.PlayOneShot(speech4);
                gas.Stop();
                gasOn = false;
            }

            if (incorrectCode && !gasOn)
            {
              if (!speech3Off)
              {
                aud.PlayOneShot(speech3);
                speech3Off = true;
              }
             incorrectCode = false;
            }
    }

    public void ScanState()
    {
        print(delayTimer);
        if (delayTimer <= 0)
        {
            delayTimer = 14f;
        }
        else
        {
            delayTimer -= Time.deltaTime;
        }
        if (canScan && !scanning && !scanComplete)
        {
            print("Scanning");
            scanning = true;
            aud.PlayOneShot(scan);
            scanComplete = true; ;
            canScan = false;
            aud.PlayOneShot(speech2);
           
        }
        if (delayTimer < 0)
        {
            robotArm.GetComponent<Animator>().SetTrigger("VoiceLine");
            rS = robotStates.speech2;
        }
    }

    public void NextSceneState()
    {
        print("Loading scene");
        if (delayTimer <= 0)
        {
            delayTimer = 10f;
        }
        else
        {
            delayTimer -= Time.deltaTime;
        }
        if (delayTimer < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
