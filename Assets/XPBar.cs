using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Character2DController character2DController;

    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        // slider.value = Character2DController.currentExperience;
        // slider.maxValue = Character2DController.maxExperience;
    }
}
