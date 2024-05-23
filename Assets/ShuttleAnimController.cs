using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleAnimController : MonoBehaviour
{
    public GameObject fireController;
    public AudioSource aud;
    public AudioClip explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartFire()
    {
        print("start fire");
        fireController.GetComponent<firespawner>().readyToStart = true;
    }
    public void StopFire()
    {
        fireController.GetComponent<firespawner>().readyToStart = false; 
    }

    public void Explosion()
    {
        aud.PlayOneShot(explosion, 2f);
    }
    public void 
}
