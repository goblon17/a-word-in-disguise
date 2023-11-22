using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Singletons/Font Animation Config", fileName = "Font Animation Config")]
public class FontAnimationConfig : ScriptableObjectSingleton<FontAnimationConfig>
{
    [SerializeField]
    private List<TMP_SpriteAsset> fonts;
    [SerializeField]
    private float delay;

    public List<TMP_SpriteAsset> Fonts => new List<TMP_SpriteAsset>(fonts);
    public float Delay => delay;
}
