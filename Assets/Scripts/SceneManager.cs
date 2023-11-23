using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform parent;

    private RectTransform currentScene;

    private void Awake()
    {
        if (GameManager.IsInstanced)
        {
            OnInstantiateGameManager();
        }
        else
        {
            GameManager.OnInstantiate += OnInstantiateGameManager;
        }
    }

    private void OnInstantiateGameManager()
    {
        GameManager.Instance.OnLevelComplete += OnLevelComplete;

        GameManager.OnInstantiate -= OnInstantiateGameManager;
    }

    private void OnLevelComplete(int nextLevel)
    {
        if (currentScene != null)
        {
            Destroy(currentScene.gameObject);
        }

        if (nextLevel < 0)
        {
            currentScene = Instantiate(LevelList.Instance.GetMenu(), parent).transform as RectTransform;
            return;
        }

        if (LevelList.Instance.TryGetLevel(nextLevel, out GameObject go))
        {
            currentScene = Instantiate(go, parent).transform as RectTransform;
        }
    }
}
