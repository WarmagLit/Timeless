using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Enemy
{
    [SerializeField] float overloadTime = 8;
    [SerializeField] Sprite[] sprites;

    protected SpriteRenderer spriteRenderer;
    protected bool overloaded = false;
    protected bool destructed = false;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        OverloadedCheck();
    }

    public void OverloadMachine()
    {
        StartCoroutine(OverloadCoroutine());
    }

    private IEnumerator OverloadCoroutine()
    {
        overloaded = true;

        yield return new WaitForSeconds(overloadTime);

        if (!destructed)
            overloaded = false;
    }

    virtual protected void OverloadedCheck()
    {
        if (!overloaded)
        {
            spriteRenderer.sprite = sprites[0];
            healthScript.SelfRegenerate();
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
            healthScript.SelfDamage();
        }
    }

    protected override void Die()
    {
        destructed = true;
        overloaded = true;
        spriteRenderer.sprite = sprites[1];
    }
}
