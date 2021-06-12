using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        CheckAlive();
        MoveInputHandle();
        MoveAbilitiesHandle();
        SwitchShootingModeHandle();
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

    private void CheckAlive()
    {
        if (!healthScript.Alive())
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("MechanicsTests");
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
}
