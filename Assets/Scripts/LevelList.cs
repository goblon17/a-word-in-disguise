using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/Level List", fileName = "Level List")]
public class LevelList : ScriptableObjectSingleton<LevelList>
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private List<GameObject> levels;

    public bool TryGetLevel(int i, out GameObject gameObject)
    {
        if (i < 0 || i >= levels.Count)
        {
            gameObject = null;
            return false;
        }

        gameObject = levels[i];
        return true;
    }

    public GameObject GetMenu()
    {
        return menu;
    }
}
