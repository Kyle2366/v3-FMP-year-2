using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float rotationPer;

    float conTime;

    private void LateUpdate()
    {
        conTime = speed * Time.deltaTime;
        transform.Rotate(rotationPer * conTime, 0, 0);
    }
}