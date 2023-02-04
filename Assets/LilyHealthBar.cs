using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LilyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public LilyHealth lilyHealth;
    public Slider sliderValue;

    void Start()
    {
        sliderValue = GetComponent<Slider>();
        lilyHealth = FindObjectOfType<LilyHealth>();
    }

    void Update()
    {
        sliderValue.value = lilyHealth.currentHealth;
    }
}
