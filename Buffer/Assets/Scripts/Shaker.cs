using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{
    public float duration = 0.7f;
    public float speed = 7.0f;
    public float magnitude = 1f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
    }

    //This function is used outside (or inside) the script
    public void PlayShake()
    {
        StopAllCoroutines();
        StartCoroutine("Shake");
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;

            float damper = 1.0f - Mathf.Clamp(1.5f * percentComplete - 1.0f, 0.0f, 1.0f);
            float alpha = randomStart + (speed * duration) * percentComplete;

            float x = Mathf.PerlinNoise(alpha, 0.0f) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0.0f, alpha) * 2.0f - 1.0f;

            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.localPosition = new Vector3(x, y, 0) + startPos;
            
           yield return 0;
        }

        while (transform.localPosition != startPos)
        {

            transform.localPosition = startPos;// Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 5f);

            yield return 0;
        }
    }
}