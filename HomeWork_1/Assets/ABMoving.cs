using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABMoving : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private float path;
    private Vector3 startPoint;
    private Vector3 finishPoint;
    private bool hasFinishReached;
    void Start()
    {
        startPoint = transform.position;
        finishPoint = new Vector3(startPoint.x, startPoint.y+5, startPoint.z);
        
    }

    void Update()
    {
        if (!hasFinishReached)
        {
            MoveUp();
        }
        if (hasFinishReached)
        {
            MoveDown();
        }

    }

    private void MoveDown()
    {
        path += Time.deltaTime;
        float movement = path / speed;
        transform.position = Vector3.Lerp(finishPoint, startPoint, movement);

        if (transform.position == startPoint)
        {
            hasFinishReached = false;
            path = 0;
        }
    }

    private void MoveUp()
    {
        path += Time.deltaTime;
        float movement = path / speed;
        transform.position = Vector3.Lerp(startPoint, finishPoint, movement);
        if (transform.position == finishPoint)
        {
            hasFinishReached = true;
            path = 0;
        }
    }
}
