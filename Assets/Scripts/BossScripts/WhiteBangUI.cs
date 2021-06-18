using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBangUI : MonoBehaviour
{
    [SerializeField] public float bangDuration = 5f;

    private CanvasGroup bangImage;
    private bool casted = false;
    public float currentAlpha = 0;
    public float currentBangTime = 0;

    void Start()
    {
        bangImage = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (casted)
        {
            currentBangTime += Time.deltaTime;
            float delta = Time.deltaTime * 255 / bangDuration;
            currentAlpha += (currentBangTime < bangDuration ? delta : -delta);
            currentAlpha = Mathf.Clamp(currentAlpha, 0, 255);

            bangImage.alpha = Mathf.Clamp(bangImage.alpha + (currentBangTime < bangDuration ? delta : -delta), 0, 255);
        }
    }

    public IEnumerator Bang()
    {
        casted = true;

        yield return new WaitForSeconds(bangDuration * 2.05f);

        casted = false;
        currentAlpha = 0;
        currentBangTime = 0;
        bangImage.alpha = 0;
    }
}
