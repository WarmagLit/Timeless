using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObelisk : Machine
{
    [SerializeField] float castTime = 10;

    private WhiteBangUI whiteBang;
    private PrototypeHeroDemo hero;
    private float bangDuration;

    protected override void Start()
    {
        base.Start();
        whiteBang = FindObjectOfType<WhiteBangUI>(); 
        hero = FindObjectOfType<PrototypeHeroDemo>();
        bangDuration = whiteBang.bangDuration;
        StartCoroutine(CastKillWave());
    }

    protected override void Update()
    {
        base.Update();
    }

    private IEnumerator CastKillWave()
    {
        yield return new WaitForSeconds(castTime);

        StartCoroutine(whiteBang.Bang());

        yield return new WaitForSeconds(bangDuration * 15f);

        hero.TakeDamage(float.MaxValue);
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
