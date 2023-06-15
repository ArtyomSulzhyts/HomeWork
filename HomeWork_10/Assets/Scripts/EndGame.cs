using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject light1;
    [SerializeField]
    GameObject light2;
    [SerializeField]
    GameObject canvas;
   
    private void EndGameCanvas()
    {
        canvas.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        light1.SetActive(true);
        light2.SetActive(true);

        Invoke("EndGameCanvas", 5f);
    }
}
