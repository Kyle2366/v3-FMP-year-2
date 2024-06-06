using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCheck : MonoBehaviour
{
    public GameObject startCapsule;
    public GameObject settingsCapsule;
    public GameObject capsuleHolder;
    public GameObject soundMaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Start")
        {
            startCapsule.GetComponent<Animator>().Play("capsule move");
            capsuleHolder.GetComponent<Animator>().Play("Take 001");
            soundMaker.GetComponent<NoiseMaker>().PlayCorrect();

        }
        if (col.gameObject.tag == "Settings")
        {
            settingsCapsule.GetComponent<Animator>().Play("capsule move");
            capsuleHolder.GetComponent<Animator>().Play("Take 001");
            soundMaker.GetComponent<NoiseMaker>().PlayCorrect();

        }
    }
}
