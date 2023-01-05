using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPuzzle : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (!Puzzle.youWin)
            transform.Rotate(0f, 0f, 90f);

    } 

}
