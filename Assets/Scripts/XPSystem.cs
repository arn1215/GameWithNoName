using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPSystem : MonoBehaviour
{
    public Slider slider;

    // Reference to the Character2DController script
    public Character2DController characterController;

    void Start()
    {
        // Find and store the Character2DController script in the scene
        characterController = FindObjectOfType<Character2DController>();
        slider = GetComponent<Slider>();
        slider.value = characterController.currentExperience;
        slider.maxValue = characterController.maxExperience;
    }

    // Update is called once per frame
    void Update()
    {
        // Update slider value and max value using the values from Character2DController
        slider.value = characterController.currentExperience;
        slider.maxValue = characterController.maxExperience;

        if (slider.value >= slider.maxValue)
        {
            // Level up logic here
            characterController.LevelUp();
        }
    }
}
