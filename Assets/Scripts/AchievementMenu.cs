using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMenu : MonoBehaviour
{
    public GameObject achievementMenu;

    public static bool isPaused;

    public Character2DController characterController;

    void Start()
    {
        achievementMenu.SetActive(false);
        characterController = FindObjectOfType<Character2DController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pauseGame()
    {
        achievementMenu.SetActive(true);

        // this stops everything
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        achievementMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void levelHearts()
    {
    }
}
