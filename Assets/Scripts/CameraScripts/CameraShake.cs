using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public void ShakeCamera(float duration, float intensity)
    {
        StartCoroutine(Shake(duration, intensity));
    }

    private IEnumerator Shake(float duration, float intensity)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float progress = elapsed / duration;

            float currentIntensity = intensity;
            if (progress > 0.7f)
            {
                float t = (progress - 0.7f) / 0.3f;
                currentIntensity = Mathf.Lerp(intensity, 0, t);
            }

            float offsetX = Random.Range(-1f, 1f) * currentIntensity;
            float offsetY = Random.Range(-1f, 1f) * currentIntensity;
            transform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
