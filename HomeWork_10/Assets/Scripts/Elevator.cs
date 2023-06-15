using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    GameObject effector;
    private float speed = 2f;
    private Vector3 startPoint;
    private Vector3 finishPoint;
    private bool isMooving = false;
    void Start()
    {
        startPoint = transform.position;
        finishPoint = new Vector3(startPoint.x, startPoint.y + 4, startPoint.z);
    }

    void Update()
    {
        if (isMooving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (transform.position.y >= 2)
        {
            isMooving = false;
            effector.SetActive(true);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isMooving = true;
    }
}
