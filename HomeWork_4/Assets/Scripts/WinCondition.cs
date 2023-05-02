using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject[] columns;
    [SerializeField]
    private TextMeshProUGUI statusInfo;
    [SerializeField]
    private GameObject buttons;
    private int fallenColumnsCounter;
    private bool isWin;
    // Start is called before the first frame update
    void Awake()
    {
        statusInfo.text = $"Columns left: {columns.Length}";
    }

    // Update is called once per frame
    void Update()
    {
        if (columns.Length == fallenColumnsCounter)
        {
            buttons.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Column")
        {
            fallenColumnsCounter++;
            statusInfo.text = $"Columns left: {columns.Length-fallenColumnsCounter}";
        }
    }
}
