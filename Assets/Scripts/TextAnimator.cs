using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextAnimator : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private FontAnimationConfig config;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        config = FontAnimationConfig.Instance;

        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        int i = 0;
        while (true)
        {
            textMesh.spriteAsset = config.Fonts[i];
            i = (i + 1) % config.Fonts.Count;
            yield return new WaitForSeconds(config.Delay);
        }
    }
}
