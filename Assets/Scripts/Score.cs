using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;

    private void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 200, 100),  "Score = " + score.ToString());
    }
}
