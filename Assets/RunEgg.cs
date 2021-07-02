using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEgg : MonoBehaviour
{
    	public PlayScript playscript1;

        public AudioSource audio;

        public GameObject drones;
        public AudioController controller;
        private float memVol = 0;
	private void Update()
	{
		ShootingHandle();
	}

	private IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Player")
		{
            Destroy(drones);
			playscript1.Run();
            controller.enabled = false;
            memVol = audio.volume;
            audio.volume = 0;

            yield return new WaitForSeconds(70);
            audio.volume = memVol;
            controller.enabled = true;
		}
	}

	private void ShootingHandle()
	{
		if (Input.GetButtonDown("Use"))
		{
			playscript1.Stop();
		}
	}

}
