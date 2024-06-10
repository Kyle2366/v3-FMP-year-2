using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject settingsCube;
    public AudioSource aud;
    public AudioClip ringsMove;
    public GameObject menu;
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
    public void OnAnimFinish2()
    {
        settingsCube.SetActive(true);
        menu.GetComponent<Animator>().Play("Menu move");
    }

    public void MenuReverse()
    {
        settingsCube.SetActive(false);
    }
    public void OnPanelSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void Music()
    {
        aud.PlayOneShot(ringsMove);
    }
}
