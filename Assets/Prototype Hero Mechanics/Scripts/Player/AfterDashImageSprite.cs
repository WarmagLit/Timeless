using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDashImageSprite : MonoBehaviour
{
    [Header("Sprite Variables")]
    [SerializeField] private float activeTime = 0.15f;
    [SerializeField] private float alphaStart = 0.8f;

    private float timeActivated;
    private float alpha;

    private Transform player;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private Color color;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = playerSpriteRenderer.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;

        alpha = alphaStart;
        timeActivated = Time.time;
        color = new Color(1f, 1f, 1f, alphaStart);
    }

    private void Update()
    {
        alpha = DecreaseAlphaStep(alpha);
        color.a = alpha;
        spriteRenderer.color = color;

        if(SpriteGoneOrTimeUp())
        {
            AfterDashImagePool.Instance.AddToPool(gameObject);
        }
    }

    private float DecreaseAlphaStep(float a)
    {
        return a - (alphaStart * Time.deltaTime) / activeTime;
    }

    private bool SpriteGoneOrTimeUp()
    {
        return Time.time >= (timeActivated + activeTime) || alpha <= Mathf.Epsilon;
    }
}
