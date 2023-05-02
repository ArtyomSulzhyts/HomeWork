using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField]
    bool rotateX = true, rotateY, rotateZ;
    [SerializeField]
    private float speed = 42f;

    void Update()
    {
        if (rotateX)
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }
        else if(rotateY)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        else if(rotateZ)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }
}
