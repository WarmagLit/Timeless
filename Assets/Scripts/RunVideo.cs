using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunVideo : MonoBehaviour
{
	public PlayScript playscript1;


	private void Update()
	{
		ShootingHandle();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(other.gameObject);
		if (other.gameObject.tag == "Player")
		{
			playscript1.Run();
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
