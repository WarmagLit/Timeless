using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhase : MonoBehaviour
{
    [SerializeField] ShootMachine mainMachine;
    [SerializeField] Transform endPortals;

    private void Update()
    {
        if (mainMachine.destructed)
        {
            mainMachine.canShoot = false;
            endPortals.gameObject.SetActive(true);
        }
    }
}
