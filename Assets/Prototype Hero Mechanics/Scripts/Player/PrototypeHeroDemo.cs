using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrototypeHeroDemo : BaseBehaviour {

    [Header("Variables")]
    [SerializeField] bool  shooting = true;
    [SerializeField] GameObject deathMenuUI;

    public PlayerHeroMovement movementScript;
    private HealthScript healthScript;
    private Shooting shootingScript;
    private Animator animator;
    private Vendetta vendettaScript;
    private PickedItem pickedItemScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponent<PlayerHeroMovement>();
        healthScript = GetComponent<HealthScript>();
        shootingScript = GetComponent<Shooting>();
        vendettaScript = GetComponent<Vendetta>();
        pickedItemScript = GetComponent<PickedItem>();
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
        UseItemHandle();
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

    public void TakeItem(Item item)
    {
        pickedItemScript.TakeItem(item);
    }

    public bool HasItem()
    {
        return pickedItemScript.HasItem();
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
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<PauseMenu>().died = true;
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

    private void UseItemHandle()
    {
        if (Input.GetButtonDown("Use Item"))
        {
            pickedItemScript.UseItem();
        }
    }
}
