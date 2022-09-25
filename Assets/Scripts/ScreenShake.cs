using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 initCamPos;

    private void Awake()
    {
        initCamPos = mainCamera.transform.position;
    }

    public void StartShakeCoroutine(float magnitude = 0.25f, float shakeTime = 0.35f)
    {
        StartCoroutine(ShakeCamera(magnitude, shakeTime));
    }

    private IEnumerator ShakeCamera(float magnitude = 0.25f, float shakeTime = 0.35f)
    {
        initCamPos = mainCamera.transform.position;
        float t = 0f;
        Vector2 shake;
        while (t < shakeTime)
        {
            shake.x = Random.Range(-1f, 1f) * magnitude;
            shake.y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.position = new Vector3(shake.x, shake.y, initCamPos.z);

            t += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = initCamPos;
    }
}
