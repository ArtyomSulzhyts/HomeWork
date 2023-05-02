using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private Rigidbody cannonRigidbody;
    [SerializeField]
    private float horizontalSpeed = 2f;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private Transform bulletPoint;
    [SerializeField]
    private Slider slider;
    private WinCondition winCondition;

    private float firingForce = 20f;
    private float verticalInput;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        cannonRigidbody.angularVelocity = horizontalInput * horizontalSpeed * transform.up;
        verticalInput = Input.GetAxis("Vertical");
        barrel.transform.Rotate(0, 0, verticalInput);

        if (Input.GetButton("Fire1"))
        {
            if (firingForce < 300)
            {
                firingForce++;
            }

            slider.value = firingForce;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject firedBullet = Instantiate(bullet,bulletPoint.position,Quaternion.identity);
            firedBullet.GetComponent<Rigidbody>().AddForce(bulletPoint.up * firingForce, ForceMode.Force);
            Debug.Log(firingForce);
            firingForce = 20f;
        }
    }
    
}
