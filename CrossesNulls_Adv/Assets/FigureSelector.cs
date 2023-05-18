using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSelector : MonoBehaviour
{
    [SerializeField]
    Figure figure;
    [SerializeField]
    TurnMaker turnMaker;
    private void OnMouseDown()
    {
        turnMaker.SelectFigure(figure);

        if ((figure.colorOfFigure == 1 && !turnMaker.isBlackPlaying) || (figure.colorOfFigure == 0 && turnMaker.isBlackPlaying))
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong turn");
        }
    }

}
