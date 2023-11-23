using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/Keywords", fileName = "Keywords")]
public class Keywords : ScriptableObjectSingleton<Keywords>
{
    [SerializeField]
    private List<string> startGame;
    [SerializeField]
    private List<string> quitGame;
    [SerializeField]
    private List<string> backToMenu;
    [SerializeField]
    private List<string> restart;
    [SerializeField]
    private List<string> winGame;
    [SerializeField]
    private List<string> nextLevel;

    public List<string> StartGame => new List<string>(startGame);
    public List<string> QuitGame => new List<string>(quitGame);
    public List<string> BackToMenu => new List<string>(backToMenu);
    public List<string> Restart => new List<string>(restart);
    public List<string> WinGame => new List<string>(winGame);
    public List<string> NextLevel => new List<string>(nextLevel);
}
