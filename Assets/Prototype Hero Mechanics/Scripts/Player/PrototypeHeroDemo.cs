using System;
using UnityEngine;

public class PrototypeHeroDemo : BaseBehaviour {

    [Header("Variables")]
    [SerializeField] bool  hideSword = true;

    private PlayerHeroMovement movementScript;
    private HealthScript healthScript;
    private Shooting shootingScript;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerHeroMovement>();
        healthScript = GetComponent<HealthScript>();
        shootingScript = GetComponent<Shooting>();
    }

    private void Update()
    {
        SwordCheck();

        MoveInputHandle();
        MoveAbilitiesHandle();
        ShootingHandle();
    }

    public void TakeDamage(float damage)
    {
        healthScript.TakeDamage(damage);
    }

    public void Heal(float healAmount)
    {
        healthScript.Heal(healAmount);
    }

    private void SwordCheck()
    {
        int hideSwordBoolInt = hideSword ? 1 : 0;
        animator.SetLayerWeight(1, hideSwordBoolInt);
    }

    private void MoveInputHandle() 
    {
        float inputX = Input.GetAxis("Horizontal");
        movementScript.MoveHero(inputX);
    }

    private void MoveAbilitiesHandle() 
    {
        if(Input.GetButtonDown("Dash"))
        {
            movementScript.Dash();
        }

        if (Input.GetButtonDown("Jump"))
        {
            movementScript.Jump();
        }
    }

    private void ShootingHandle()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shootingScript.Shoot());
        }
    }
}
