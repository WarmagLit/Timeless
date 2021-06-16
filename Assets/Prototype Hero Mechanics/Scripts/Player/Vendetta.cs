using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class Vendetta : MonoBehaviour
{
    private float currentTimeScale = 1;

    public void CastVendetta()
    {
        Clock clock = Timekeeper.instance.Clock("Enemies");
        currentTimeScale = 1 - currentTimeScale;
        clock.localTimeScale = currentTimeScale;
    }
}
