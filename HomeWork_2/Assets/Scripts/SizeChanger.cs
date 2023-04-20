using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SizeChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] initialObjects;
    
    [SerializeField]
    private Slider sizeSlider;
    [SerializeField]
    private Slider sideSlider;
    [SerializeField]
    private Button paintButton;

    [Header("Positions")]

    [SerializeField]
    private TextMeshProUGUI rotation;
    [SerializeField]
    private TextMeshProUGUI scale;



    private int objectIndex;
    private GameObject currentObject;


    void Awake()
    {
        currentObject = initialObjects[0];
        currentObject.SetActive(true);
        sizeSlider.onValueChanged.AddListener(ChangeSize);
        sideSlider.onValueChanged.AddListener(Turn);
        paintButton.onClick.AddListener(Paint);
    }

    private void Paint()
    {
        MeshRenderer objectColor = initialObjects[objectIndex].GetComponentInChildren<MeshRenderer>();
        objectColor.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        Image buttonImage = paintButton.GetComponent<Image>();
        buttonImage.color = objectColor.material.color;
    }

    private void Turn(float value) 
    {
        float turn = value * 360;
        initialObjects[objectIndex].transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, turn, 0));
    }

    private void ChangeSize(float value)
    {
        var size = value * 3;
        initialObjects[objectIndex].transform.localScale = new Vector3(size,size,size);
    }

    public void ExampleInt(int value)
    {
        switch (value)
        {
            case 0:
                objectIndex = 0;
                currentObject.SetActive(false);
                currentObject = initialObjects[objectIndex];
                currentObject.SetActive(true);
                break;
            case 1:
                objectIndex = 1;
                currentObject.SetActive(false);
                currentObject = initialObjects[objectIndex];
                currentObject.SetActive(true);
                break;
            case 2:
                objectIndex = 2;
                currentObject.SetActive(false);
                currentObject = initialObjects[objectIndex];
                currentObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void CurrentPosition()
    {
        rotation.text = "Rotation : " + currentObject.transform.rotation.y;
        scale.text = "Scale : " + currentObject.transform.localScale.x;
    }

    private void Update()
    {
        CurrentPosition();
    }

}

