using System.Collections;
using UnityEngine;

public class BlinkAndDestroy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float blinkIntervalTime = 0.1f;
    [SerializeField] private float blinkDelay = 6;
    [SerializeField] private float DestroyTime = 10;

    private void Start()
    {
        StartCoroutine(ActivateBlink());
        Destroy(gameObject, DestroyTime);
    }

    private IEnumerator ActivateBlink()
    {
        yield return new WaitForSeconds(blinkDelay);
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            spriteRenderer.enabled = spriteRenderer.enabled ? false : true;
            yield return new WaitForSeconds(blinkIntervalTime);
        }
    }
}
