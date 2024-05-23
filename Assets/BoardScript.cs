using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardScript : MonoBehaviour
{
    public GameObject cube;
    public AudioSource aud;
    public AudioClip ringsMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimFinish()
    {
        cube.SetActive(true);
    }

    public void OnPanelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void Music()
    {
        aud.PlayOneShot(ringsMove);
    }
}
