using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBangUI : MonoBehaviour
{
    [SerializeField] public float bangDuration = 1f;

    private CanvasGroup bangImage;
    private bool casted = false;
    public float currentAlpha = 0;

    void Start()
    {
        bangImage = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (casted)
        {
            float delta = Time.deltaTime * 255 / bangDuration;
            currentAlpha += delta;
            currentAlpha = Mathf.Clamp(currentAlpha, 0, 255);

            bangImage.alpha = Mathf.Clamp(bangImage.alpha + delta, 0, 255);
        }
    }

    public IEnumerator Bang()
    {
        casted = true;

        yield return new WaitForSeconds(bangDuration * 1.1f);

        casted = false;
        currentAlpha = 0;
        bangImage.alpha = 0;
    }
}
