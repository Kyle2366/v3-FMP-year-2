using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    firespawner fS;
    public Transform sprayPoint;
    public int shotDis = 1000;
    public ParticleSystem foam;

    public float aliveTime;

    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        aliveTime = 10;
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

            aliveTime -= Time.deltaTime;
            if (aliveTime <= 0)
            {
                Destroy(gameObject);    
            }
            foam.gameObject.SetActive(true);
            print("SPRAY");
            if (Physics.Raycast(sprayPoint.position, transform.right, out RaycastHit hitInfo, shotDis))
            {
                if (hitInfo.collider.tag == "fire1")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire1On = false;
                    hitInfo.collider.gameObject.GetComponent<firespawner>().fireCount--;
                }
                if (hitInfo.collider.tag == "fire2")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire2On = false;
                }
                if (hitInfo.collider.tag == "fire3")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire3On = false;
                }
                if (hitInfo.collider.tag == "fire4")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire4On = false;
                }
                if (hitInfo.collider.tag == "fire5")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
                    print("fire hit");
                    hitInfo.collider.gameObject.SetActive(false);
                    hitInfo.collider.gameObject.GetComponent<firespawner>().Fire5On = false;
                }
                if (hitInfo.collider.tag == "fire6")
                {
                    hitInfo.collider.GetComponentInParent<firespawner>().fireCount--;
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
