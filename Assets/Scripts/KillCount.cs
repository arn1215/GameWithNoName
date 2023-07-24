using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public static int count = 0;

    public Text text;

    // public void IncrementCount()
    // {
    //     count++;
    // }
    public void Update()
    {
        text.text = "KILLS: " + count.ToString();
    }
}
