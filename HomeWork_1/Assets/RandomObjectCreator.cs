using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomObjectCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabsExampls;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Random rand = new Random();


            int index = rand.Next(0, prefabsExampls.Length);
            Vector3 randomPosition = new Vector3(rand.Next(-5, 5), rand.Next(-5, 5), rand.Next(-5, 5));

            Instantiate(prefabsExampls[index], randomPosition, Quaternion.identity);
        }
    }
}
