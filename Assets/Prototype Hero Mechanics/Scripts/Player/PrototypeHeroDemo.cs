using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrototypeHeroDemo : BaseBehaviour {

    [Header("Variables")]
    [SerializeField] bool  shooting = true;

    private PlayerHeroMovement movementScript;
    private HealthScript healthScript;
    private Shooting shootingScript;
    private Animator animator;
    private Vendetta vendettaScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerHeroMovement>();
        healthScript = GetComponent<HealthScript>();
        shootingScript = GetComponent<Shooting>();
        vendettaScript = GetComponent<Vendetta>();
    }

    private void Update()
    {
        ShootAnimationCheck();

        CheckAlive();
        MoveInputHandle();
        MoveAbilitiesHandle();
        SwitchShootingModeHandle();
        ShootingHandle();
        VendettaHandle();
    }

    public void TakeDamage(float damage)
    {
        healthScript.TakeDamage(damage);
    }

    public void Heal(float healAmount)
    {
        healthScript.Heal(healAmount);
    }

    public void BoostUp(float boostScript)
    {
        movementScript.BoostUp(boostScript);
    }

    private void ShootAnimationCheck()
    {
        int shootingInt = shooting ? 1 : 0;
        animator.SetLayerWeight(1, shootingInt);
    }

    private void CheckAlive()
    {
        if (!healthScript.Alive())
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    private void SwitchShootingModeHandle()
    {
        if (Input.GetButtonDown("Switch Shooting Mode"))
        {
            shootingScript.SwitchMode();
        }
    }

    private void ShootingHandle()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootingScript.Shoot();
        }
    }

    private void VendettaHandle()
    {
        if (Input.GetButtonDown("Vendetta"))
        {
            vendettaScript.CastVendetta();
        }
    }
}
