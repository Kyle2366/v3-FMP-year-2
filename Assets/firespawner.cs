using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class firespawner : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip explode;
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Fire4;
    public GameObject Fire5;
    public GameObject Fire6;

    public bool Fire1On;
    public bool Fire2On;
    public bool Fire3On;
    public bool Fire4On;
    public bool Fire5On;
    public bool Fire6On;
    public int fireCount;

    public bool readyToStart;

    public float timer;
    public float timeToDeath;
    public bool countdown;
    public bool deathCountdown;
    int[] fireList = { 1, 2, 3, 4, 5, 6 };
    int fireIndex;
    
    void Start()
    {
        readyToStart = false;
        Fire1On = false;
        Fire2On = false;
        Fire3On = false;
        Fire4On = false;
        Fire5On = false;
        Fire6On = false;
        countdown = false;
        deathCountdown = false;
        fireIndex = 1;
    }

    
    void Update()
    {
        if (readyToStart)
        {
            Spawner();
        }
  
        DeathCount();
        print("death counter time left;" + timeToDeath);
    }

    public void Spawner()
    {
        
       timer -= Time.deltaTime;
        if (!countdown)
        {
            print("FIRE ON");
            timer = Random.Range(6, 10);
            countdown = true;
            fireIndex = Random.Range(1, 6);
            if (fireList[fireIndex] == 1 && !Fire1On)
            {
                fireCount++;
                Fire1.SetActive(true);
                
            }
            if (fireList[fireIndex] == 2 && !Fire2On)
            {
                fireCount++;
                Fire2.SetActive(true);
            }
            if (fireList[fireIndex] == 3 && !Fire3On)
            {
                fireCount++;
                Fire3.SetActive(true);
            }
            if (fireList[fireIndex] == 4 && !Fire4On)
            {
                fireCount++;
                Fire4.SetActive(true);
            }
            if (fireList[fireIndex] == 5 && !Fire5On)
            {
                fireCount++;
                Fire5.SetActive(true);
            }
            if (fireList[fireIndex] == 6 && !Fire6On)
            {
                fireCount++;
                Fire6.SetActive(true);
            }
        }
        if (timer <= 0)
        {
            countdown = false;
        }
    }

    public void DeathCount()
    {
        if (fireCount < 1 )
        {
            deathCountdown = false;
            timeToDeath = 100;
            print(timeToDeath);
        }
        if (fireCount >= 2 && !deathCountdown)
        {
            deathCountdown = true;
            timeToDeath = 10f;
        }
        if (deathCountdown)
        {
            
            if (fireCount == 3)
            {
                timeToDeath--;
            }
            if (fireCount > 3)
            {
                timeToDeath --;
            }
            timeToDeath -= Time.deltaTime;
        }
        if (deathCountdown && timeToDeath <= 1)
        {
            aud.PlayOneShot(explode, 2f);
            aud.PlayOneShot(explode, 2f);
        }

        if (deathCountdown && timeToDeath <= 0)
        {
            print("DEAD");
            SceneManager.LoadScene(0);
        }
    }
}
