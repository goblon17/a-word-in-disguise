using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event System.Action<int> OnLevelComplete;

    private int currentLevel = 0;
    private bool menu = true;

    private void Start()
    {
        currentLevel = 0;
        EnterMenu();
    }

    public void SubmitInput(string input)
    {
        input = input.Trim().ToLower();
        if (MenuCheckInput(input))
        {
            return;
        }
        if (LevelCheckInput(input))
        {
            return;
        }
        if (GameControllCheckInput(input))
        {
            return;
        }
    }

    private bool MenuCheckInput(string input)
    {
        if (menu)
        {
            switch (input)
            {
                case "start" or "play":
                    LeaveMenu();
                    return true;
            }
        }
        return false;
    }

    private bool LevelCheckInput(string input)
    {
        return false;
    }

    private bool GameControllCheckInput(string input)
    {
        if (input == "quit")
        {
            Application.Quit();
        }
        return false;
    }

    private void LeaveMenu()
    {
        menu = false;
        OnLevelComplete?.Invoke(currentLevel);
    }

    private void EnterMenu()
    {
        menu = true;
        OnLevelComplete?.Invoke(-1);
    }
}
