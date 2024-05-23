using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCheck : MonoBehaviour
{
    public GameObject capsule;
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
        if (col.gameObject.tag == "card")
        {
            capsule.GetComponent<Animator>().Play("capsule move");
            capsuleHolder.GetComponent<Animator>().Play("Take 001");
            soundMaker.GetComponent<NoiseMaker>().PlayCorrect();

        }
    }
}
