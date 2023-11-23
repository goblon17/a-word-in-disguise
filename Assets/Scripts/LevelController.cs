using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private List<string> winWords;

    public List<string> WinWords => new List<string>(winWords);
}
