using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{

    public int firstDigit = 4;
    public int secondDigit = 5;
    public int thirdDigit = 1;

    public bool isPassTrue;
    public GameObject laserGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PassCodeCheck(bool pause)
    {
        if (isPassTrue)
        {
            laserGate.SetActive(false);
        }

    }
}
