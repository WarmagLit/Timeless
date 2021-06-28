using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhase : MonoBehaviour
{
    public float machinesToDestroyCount;
    public DroneWaveSpawner droneSpawner;
    public DeathObeliskSpawner obeliskSpawner;
    public Transform barrier;

    private List<Machine> shootMachines = new List<Machine>();
    private bool secondPhaseStarted = false;
    private bool changingPhases = false;

    void Update()
    {
        if (!secondPhaseStarted && !changingPhases)
        {
            PhaseCheck();
        }
        else if (!secondPhaseStarted && changingPhases)
        {
            ChangePhase();
        }
    }

    public void AddDestructedMachine(Machine machine)
    {
        shootMachines.Add(machine);
    }

    private void PhaseCheck()
    {
        if (shootMachines.Count == machinesToDestroyCount)
            changingPhases = true;
    }

    private void ChangePhase()
    {
        droneSpawner.gameObject.SetActive(false);
        obeliskSpawner.gameObject.SetActive(false);
        barrier.gameObject.SetActive(false);

        foreach (var machine in shootMachines)
        {
            machine.DisableMachine();
        }
        KillAllDrones();

        secondPhaseStarted = true;
    }

    private void KillAllDrones()
    {
        foreach (var drone in FindObjectsOfType<Drone>())
        {
            drone.TakeDamage(float.MaxValue);
        }
    }
}
