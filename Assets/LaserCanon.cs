using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCanon : MonoBehaviour
{

    public GameObject laser;
    public GameObject canon;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireShot()
    {
        canon.transform.LookAt(player.transform.position);
        laser.SetActive(true);
        
    }
}
