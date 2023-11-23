using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform parent;
    [SerializeField]
    private float moveDuration;

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
            StartCoroutine(LeaveCoroutine(currentScene));
            currentScene = null;
        }

        if (nextLevel < 0)
        {
            currentScene = Instantiate(LevelList.Instance.GetMenu(), parent).transform as RectTransform;
            GameManager.Instance.WinWords = null;
            StartCoroutine(EnterCoroutine(currentScene));
            return;
        }

        if (LevelList.Instance.TryGetLevel(nextLevel, out GameObject go))
        {
            currentScene = Instantiate(go, parent).transform as RectTransform;
            GameManager.Instance.WinWords = currentScene.GetComponent<LevelController>().WinWords;
            StartCoroutine(EnterCoroutine(currentScene));
        }
        else
        {
            currentScene = Instantiate(LevelList.Instance.GetWin(), parent).transform as RectTransform;
            GameManager.Instance.WinWords = null;
            StartCoroutine(EnterCoroutine(currentScene));
        }
    }

    private IEnumerator LeaveCoroutine(RectTransform rectTransform)
    {
        yield return UIUtils.AnimateRectTransformAnchoredPositionCoroutine(rectTransform, moveDuration, new Vector2(-rectTransform.rect.width, 0), rectTransform.sizeDelta);

        Destroy(rectTransform.gameObject);
    }

    private IEnumerator EnterCoroutine(RectTransform rectTransform)
    {
        currentScene.anchoredPosition = new Vector2(currentScene.rect.width, 0);

        yield return UIUtils.AnimateRectTransformAnchoredPositionCoroutine(rectTransform, moveDuration, new Vector2(0, 0), rectTransform.sizeDelta);
    }
}
