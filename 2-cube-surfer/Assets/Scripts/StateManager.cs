using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static Action noCubesLeft;
    public static Action finish;

    public GameObject cubeStack;
    public GameObject finishLine;

    public void Start()
    {
        noCubesLeft += playerFail;
        finish += playerWin;
    }

    public void playerFail()
    {
        if (cubeStack.transform.childCount == 2)
        {
            UIManager.showFail();
        }
    }

    public void playerWin()
    {
        UIManager.showWin();
    }

    public void OnDestroy()
    {
        noCubesLeft -= playerFail;
        finish -= playerWin;
    }
}
