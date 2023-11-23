using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event System.Action<int> OnLevelComplete;

    public List<string> WinWords
    {
        set => winWords = value == null ? value :  new List<string>(value);
    }

    private int currentLevel = 0;
    private bool menu = true;

    private Keywords keywords;

    private List<string> winWords;

    protected override void Awake()
    {
        keywords = Keywords.Instance;

        base.Awake();
    }

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
                case string a when keywords.StartGame.Contains(a):
                    LeaveMenu();
                    return true;
            }
        }
        return false;
    }

    private bool LevelCheckInput(string input)
    {
        if (winWords == null)
        {
            return false;
        }

        if (winWords.Contains(input) || winWords.Contains("ANYTHING"))
        {
            NextLevel();
            return true;
        }

        return false;
    }

    private bool GameControllCheckInput(string input)
    {
        switch (input)
        {
            case string a when keywords.QuitGame.Contains(a):
                Application.Quit();
                return true;
            case string a when keywords.BackToMenu.Contains(a):
                if (!menu)
                {
                    EnterMenu();
                    return true;
                }
                break;
            case string a when keywords.Restart.Contains(a):
                if (!menu)
                {
                    EnterMenu();
                }
                currentLevel = 0;
                return true;
            case string a when keywords.WinGame.Contains(a):
                GoToWin();
                return true;
            case string a when keywords.NextLevel.Contains(a):
                if (!menu)
                {
                    NextLevel();
                    return true;
                }
                break;
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
        if (currentLevel >= LevelList.Instance.LevelCount)
        {
            currentLevel = 0;
        }
        OnLevelComplete?.Invoke(-1);
    }

    private void NextLevel()
    {
        menu = false;
        currentLevel++;
        OnLevelComplete?.Invoke(currentLevel);
    }

    private void GoToWin()
    {
        menu = false;
        currentLevel = LevelList.Instance.LevelCount;
        NextLevel();
    }
}
