using System.Collections;
using System.Collections.Generic;
using Chronos;
using UnityEngine;

public class TimeScriptOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Enemies global clock
        Clock clock = Timekeeper.instance.Clock("Character");

        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.X))
        {
            clock.localTimeScale = -1; // Rewind
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            clock.localTimeScale = 0; // Pause
            //clock.LerpTimeScale(0, 2, true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            clock.localTimeScale = 0.5f; // Slow
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            clock.localTimeScale = 1; // Normal
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            clock.localTimeScale = 2; // Accelerate
        }
    }
}
