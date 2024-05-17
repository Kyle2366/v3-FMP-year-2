using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    firespawner fS;
    public Transform sprayPoint;
    public int shotDis = 10;
    public ParticleSystem foam;

    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

        Spray();
    }

    public void Spray()
    {
        if (active)
        {
            foam.gameObject.SetActive(true);
            print("SPRAY");
            if (Physics.Raycast(sprayPoint.position, transform.forward, out RaycastHit hitInfo, shotDis))
            {
                if (hitInfo.collider.tag == "fire1")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire1On = false;
                }
                if (hitInfo.collider.tag == "fire2")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire2On = false;
                }
                if (hitInfo.collider.tag == "fire3")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire3On = false;
                }
                if (hitInfo.collider.tag == "fire4")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire4On = false;
                }
                if (hitInfo.collider.tag == "fire5")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire5On = false;
                }
                if (hitInfo.collider.tag == "fire6")
                {
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire6On = false;
                }
                else
                {
                    print("No fire here");
                }
            }
        }
        if (!active)
        {
            foam.gameObject.SetActive(false);
        }
    }

    public void Active()
    {
        print("ACTIVATE");
        active=true;
    } 
    public void NotActive()
    {
        print("Deactivate");
        active = false;
    }
}
