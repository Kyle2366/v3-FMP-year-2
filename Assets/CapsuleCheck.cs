using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCheck : MonoBehaviour
{
    public GameObject boards;
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
        print("Capsule");
        print(col.gameObject.name);
        if (col.gameObject.tag == "Start")
        {
            print("start animation");
            boards.GetComponent<Animator>().Play("OnCardInput");
        }
        if (col.gameObject.tag == "Settings")
        {
            print("Setting animation");
            boards.GetComponent<Animator>().Play("OnSettingsCardInput");
        }
    }
}
