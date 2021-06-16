using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformScript : MonoBehaviour
{
    [SerializeField] float jumpForce = 16;

    private void OnTriggerEnter2D(Collider2D jumpInfo)
    {
        PrototypeHeroDemo hero = jumpInfo.transform.GetComponent<PrototypeHeroDemo>();

        if (hero != null)
        {
            hero.BoostUp(jumpForce);
        }
    }
}
