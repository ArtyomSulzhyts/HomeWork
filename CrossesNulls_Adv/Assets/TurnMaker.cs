using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaker : MonoBehaviour
{
    Figure selectedFigure;
    public bool isBlackPlaying;
    public int isBlackWin = 0;
    Figure[] figures3 = new Figure[3];
    Figure[] figures4 = new Figure[3];
    Figure[] figures5 = new Figure[3];
    private void OnMouseDown()
    {

        if (!isBlackPlaying && selectedFigure.colorOfFigure == 1)
        {
            PutFigure(GetClick());
            Debug.Log(2);
            isBlackPlaying = true;
        }
        if (isBlackPlaying && selectedFigure.colorOfFigure == 0)
        {
            PutFigure(GetClick());
            Debug.Log(3);
            isBlackPlaying = false;
        }
        
    }
    private Vector2 GetClick()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 boardPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 roundedPositions = RoundToBoardPosition(boardPosition);
        return roundedPositions;
    }
    private Vector2 RoundToBoardPosition(Vector2 boardPosition)
    {
        float roundedX = Mathf.RoundToInt(boardPosition.x);
        float roundedY = Mathf.RoundToInt(boardPosition.y);
        return new Vector2(roundedX, roundedY);
    }

    public void SelectFigure(Figure figure)
    {
        selectedFigure = figure;
    }
    private void PutFigure(Vector2 boardPosition)
    {

        Instantiate(selectedFigure, boardPosition, Quaternion.identity);

        int y = (int)boardPosition.y;
        Debug.Log(1);
        if (boardPosition.x == 3)
        {
            figures3[y - 2] = selectedFigure;
        }
        if (boardPosition.x == 4)
        {
            figures4[y - 2] = selectedFigure;
        }
        if (boardPosition.x == 5)
        {
            figures5[y - 2] = selectedFigure;
        }

        //WinCheck();
    }

    private void WinCheck()
    {
        int check1 = figures3[0].colorOfFigure + figures4[0].colorOfFigure + figures5[0].colorOfFigure;
        int check2 = figures3[1].colorOfFigure + figures4[1].colorOfFigure + figures5[1].colorOfFigure;
        int check3 = figures3[2].colorOfFigure + figures4[2].colorOfFigure + figures5[2].colorOfFigure;
        int check4 = figures3[0].colorOfFigure + figures3[1].colorOfFigure + figures3[2].colorOfFigure;
        int check5 = figures4[0].colorOfFigure + figures4[1].colorOfFigure + figures4[2].colorOfFigure;
        int check6 = figures5[0].colorOfFigure + figures5[1].colorOfFigure + figures5[2].colorOfFigure;
        int check7 = figures3[0].colorOfFigure + figures4[1].colorOfFigure + figures5[2].colorOfFigure;
        int check8 = figures3[2].colorOfFigure + figures4[1].colorOfFigure + figures5[0].colorOfFigure;

        int[] checks = new int[] { check1, check2, check3, check4, check5, check6, check7, check8 };

        for (int i = 0; i < checks.Length; i++)
        {
            if (checks[i] == 3)
            {
                isBlackWin = 1;
                Debug.Log("White wins! Congrats!");
                return;
            }
            else if (checks[i] == 0)
            {
                isBlackWin = 2;
                Debug.Log("Oh, God! Black wins!");
            }

            else
            {
                Debug.Log("We have a draw! Someone's cheating (Black)");
            }
        }

    }

}
