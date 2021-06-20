using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunVideo : MonoBehaviour
{
	public PlayScript playscript1;

	[SerializeField] GameObject dialogueCanvas;

	private void Update()
	{
		ShootingHandle();
	}

	private IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(other.gameObject);
		if (other.gameObject.tag == "Player")
		{
			playscript1.Run();

			yield return new WaitForSeconds(5);

			dialogueCanvas.SetActive(true);
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
