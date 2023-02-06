using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float playedTime;

    public Text time;

    void Start()
    {
        playedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playedTime += Time.deltaTime;
        time.text = Mathf.RoundToInt(playedTime).ToString();
    }
}
