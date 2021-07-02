using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObelisk : Machine
{
    [SerializeField] float castTime = 9.5f;

    public DurationImage deathTimer;

    private WhiteBangUI whiteBang;
    private PrototypeHeroDemo hero;
    private float bangDuration;
    private float currentCastTime;

    protected override void Start()
    {
        base.Start();
        whiteBang = FindObjectOfType<WhiteBangUI>(); 
        hero = FindObjectOfType<PrototypeHeroDemo>();
        bangDuration = whiteBang.bangDuration;
        currentCastTime = 0;
        StartCoroutine(CastKillWave());
    }

    protected override void Update()
    {
        base.Update();
        currentCastTime += Time.deltaTime;

        if (currentCastTime < castTime)
        {
            deathTimer.SetCurrentDuration(currentCastTime / castTime);
        }
        else
        {
            deathTimer.HideIcon();
        }
    }

    private IEnumerator CastKillWave()
    {
        yield return new WaitForSeconds(castTime);

        whiteBang.Bang();

        yield return new WaitForSeconds(bangDuration);

        hero.TakeDamage(float.MaxValue);
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
