using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    public delegate void ExperienceChangeHandler(int amount);

    public event ExperienceChangeHandler OnExperienceChange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this); // Use "gameObject" to destroy the duplicate instance.
        }
        else
        {
            Instance = this;
        }
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(1);
        LilyHealth.instance.HealPlayer(40);
        print("triggered");
    }
}
