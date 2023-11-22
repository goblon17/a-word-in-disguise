using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Singletons/Font Animation Config", fileName = "Font Animation Config")]
public class FontAnimationConfig : ScriptableObjectSingleton<FontAnimationConfig>
{
    [SerializeField]
    private List<TMP_FontAsset> fonts;
    [SerializeField]
    private float delay;

    public List<TMP_FontAsset> Fonts => new List<TMP_FontAsset>(fonts);
    public float Delay => delay;
}
