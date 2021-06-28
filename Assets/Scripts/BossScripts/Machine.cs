using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Enemy
{
    [SerializeField] float overloadTime = 8;
    [SerializeField] Sprite[] sprites;
    [SerializeField] public bool canShoot = false;
    [SerializeField] protected Transform healZone;

    protected SpriteRenderer spriteRenderer;
    protected bool overloaded = false;
    public bool destructed { get; protected set; }

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

    public void DisableMachine()
    {
        enabled = false;
    }

    public void OverloadMachine()
    {
        StartCoroutine(OverloadCoroutine());
    }

    private IEnumerator OverloadCoroutine()
    {
        overloaded = true;
        healZone.gameObject.SetActive(false);

        yield return new WaitForSeconds(overloadTime);

        if (!destructed)
        {
            overloaded = false;
            healZone.gameObject.SetActive(true);
        } 
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
        canShoot = true;
        spriteRenderer.sprite = sprites[1];
    }
}
