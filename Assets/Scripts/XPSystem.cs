using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPSystem : MonoBehaviour
{
    public Slider slider;

    public static int xpLevel = 1;

    public static int xpFromKills = 0;

    void Start()
    {
        slider.value = 0;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= 100)
        {
            xpLevel++;
            slider.value = 0;
        }
        if (xpLevel < 20)
        {
            slider.value = KillCount.count * 20;
        }
    }
}
