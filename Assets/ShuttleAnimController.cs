using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShuttleAnimController : MonoBehaviour
{
    public GameObject fireController;
    public AudioSource aud;
    public AudioClip explosion;
    public AudioClip fireWarn;
    public AudioClip end;
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
    public void FireWarning()
    {
        aud.PlayOneShot(fireWarn, 2f);
    }

    public void EndOfLevel()
    {
        aud.PlayOneShot(end, 2f);
        Invoke("Restart", 6f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
