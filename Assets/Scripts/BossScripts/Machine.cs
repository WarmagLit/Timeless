using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Enemy
{
    public Sprite[] sprites;
    public bool overloaded = false;

    protected SpriteRenderer spriteRenderer;
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
