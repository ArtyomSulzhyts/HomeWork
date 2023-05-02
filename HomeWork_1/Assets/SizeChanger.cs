using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField]
    private float timeGrow = 2f;
    private float sizeGrow;
    private Vector3 maxSize = new Vector3(3, 3, 3);
    private Vector3 minSize = new Vector3(1, 1, 1);
    private bool isGrow = true;

    void Update()
    {
        
        if (isGrow)
        {
            Grow();
        }
        else
        {
            Fall();
        }
    }

    private void Fall()
    {
        sizeGrow += Time.deltaTime;
        float growth = sizeGrow / timeGrow;
        transform.localScale = Vector3.Lerp(maxSize, minSize, growth);

        if (transform.localScale == minSize)
        {
            isGrow = true;
            sizeGrow = 0;
        }
    }

    private void Grow()
    {
        sizeGrow += Time.deltaTime;
        float growth = sizeGrow / timeGrow;
        transform.localScale = Vector3.Lerp(minSize, maxSize, growth);

        if (transform.localScale == maxSize)
        {
            isGrow = false;
            sizeGrow = 0;
        }
    }
}
