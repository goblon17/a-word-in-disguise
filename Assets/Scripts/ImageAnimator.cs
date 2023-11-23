using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAnimator : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites;

    private Image image;
    private FontAnimationConfig config;

    private void Start()
    {
        image = GetComponent<Image>();
        config = FontAnimationConfig.Instance;

        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        int i = 0;
        while (true)
        {
            image.sprite = sprites[i];
            i = (i + 1) % sprites.Count;
            yield return new WaitForSeconds(config.Delay);
        }
    }
}
