
using System.Collections;
using UnityEngine;

using Random = System.Random;

public class Teleporting : MonoBehaviour
{
    [SerializeField]
    private float time = 3f;

    void Start()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        Random rand = new Random(); 
        while (true)
        {
            transform.position = new Vector3(rand.Next(-5, 5), rand.Next(-5, 5), 0);
            yield return new WaitForSeconds(time);
        }      
    }
}
