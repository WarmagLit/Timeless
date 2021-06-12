using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float maxSpeed = 6.5f;
    [SerializeField] float jumpForce = 7.5f;

    [Header("Effects")]
    [SerializeField] GameObject RunStopDust;
    [SerializeField] GameObject JumpDust;
    [SerializeField] GameObject LandingDust;

    [Header("Dash Variables")]
    [SerializeField] private float dashTime = 0.15f;
    [SerializeField] private float dashSpeed = 50;
    [SerializeField] private float distanceBetweenImages = 0.6f;
    [SerializeField] private float dashCooldown = 1;

    private Animator animator;
    private Rigidbody2D body2d;
    private GroundSensorHero groundSensor;
    private AudioManager_PrototypeHero audioManager;

    private bool grounded = false;
    private bool canJump = true;
    private bool moving = false;
    private int facingDirectionInt = 1;

    private bool dashing = false;
    private float dashTimeLeft;
    private float lastImageXPosition;
    private float lastDash = -100;

    private const float runStopDustXOffset = 0.6f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        audioManager = AudioManager_PrototypeHero.instance;
        groundSensor = transform.Find("GroundSensor").GetComponent<GroundSensorHero>();
    }

    private void Update()
    {
        animator.SetFloat("AirSpeedY", body2d.velocity.y);

        GroundedCheck();
        CheckDash();
    }

    public void MoveHero(float inputX)
    {
        moving = Mathf.Abs(inputX) > Mathf.Epsilon && Mathf.Sign(inputX) == facingDirectionInt;
        HeroDirection(inputX);
        Movement(inputX);
    }

    public void Dash()
    {
        if (DashReady())
        {
            dashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;

            PlaceNextAfterDashImage();
        }
    }

    public void Jump()
    {
        if (grounded || canJump)
        {
            canJump = grounded;
            JumpAnimation();
            body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
        }
    }

    public void BoostUp(float boostForce)
    {
        float yVelocity = -Mathf.Clamp(body2d.velocity.y, -3, -1) * boostForce;
        JumpAnimation();
        body2d.velocity = new Vector2(body2d.velocity.x, yVelocity);
    }

    private void GroundedCheck()
    {
        GroundedUpdate(groundSensor.State());
    }

    private void GroundedUpdate(bool grounded)
    {
        this.grounded = grounded;
        canJump = grounded || canJump;
        animator.SetBool("Grounded", this.grounded);
    }

    private void HeroDirection(float inputX)
    {
        if (DirectionChanged(inputX))
            FlipHero();
    }

    private bool DirectionChanged(float inputX)
    {
        return Mathf.Abs(inputX) > Mathf.Epsilon && facingDirectionInt != (int)Mathf.Sign(inputX);
    }

    private void FlipHero()
    {
        transform.Rotate(0f, 180f, 0f);
        facingDirectionInt = -facingDirectionInt;
    }

    private void Movement(float inputX)
    {
        if (!dashing)
        {
            float SlowDownSpeed = moving ? 1.0f : 0.1f;
            body2d.velocity = new Vector2(inputX * maxSpeed * SlowDownSpeed, body2d.velocity.y);
        }
        MovementAnimation();
    }

    private void MovementAnimation()
    {
        int movingBoolInt = grounded && moving ? 1 : 0;
        animator.SetInteger("AnimState", movingBoolInt);
    }

    private bool DashReady()
    {
        return Time.time >= (lastDash + dashCooldown);
    }

    private void CheckDash()
    {
        if (dashing)
        {
            if (dashTimeLeft > 0)
            {
                body2d.velocity = new Vector2(dashSpeed * facingDirectionInt, 0);
                dashTimeLeft -= Time.deltaTime;

                if (CanPlaceNextImage())
                {
                    PlaceNextAfterDashImage();
                }
            }
            else
            {
                dashing = false;
            }
        }
    }

    private bool CanPlaceNextImage()
    {
        return Mathf.Abs(transform.position.x - lastImageXPosition) > distanceBetweenImages;
    }

    private void PlaceNextAfterDashImage()
    {
        AfterDashImagePool.Instance.GetFromPool().GetComponent<SpriteRenderer>();
        lastImageXPosition = transform.position.x;
    }

    private void JumpAnimation()
    {
        animator.SetTrigger("Jump");
        GroundedUpdate(false);
        groundSensor.Disable(0.2f);
    }


    void AE_runStop()
    {
        audioManager.PlaySound("RunStop");
        SpawnDustEffect(RunStopDust, runStopDustXOffset);
    }

    void AE_footstep()
    {
        audioManager.PlaySound("Footstep");
    }

    void AE_Jump()
    {
        audioManager.PlaySound("Jump");
        SpawnDustEffect(JumpDust);
    }

    void AE_Landing()
    {
        audioManager.PlaySound("Landing");
        SpawnDustEffect(LandingDust);
    }

    private void SpawnDustEffect(GameObject dust, float dustXOffset = 0)
    {
        if (dust != null)
        {
            Vector3 dustSpawnPosition = transform.position + new Vector3(dustXOffset * facingDirectionInt, 0.0f, 0.0f);
            GameObject newDust = Instantiate(dust, dustSpawnPosition, Quaternion.identity) as GameObject;

            newDust.transform.localScale = newDust.transform.localScale.x * new Vector3(facingDirectionInt, 1, 1);
        }
    }
}
