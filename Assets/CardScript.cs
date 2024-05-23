using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    RobotAudio rA;
    public GameObject card;
    public Transform cardPoint;
    public GameObject robotAudio;
    public GameObject shuttle;


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
        if (col.gameObject.tag == "Card")
        {
            print("Card Slot!");
            robotAudio.GetComponent<RobotAudio>().cardInsert = true;
            shuttle.GetComponent<Animator>().Play("move");
        }
    }
}
