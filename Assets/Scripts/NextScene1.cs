using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene1 : MonoBehaviour
{
	public bool isEnabled = false;
	private void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(other.gameObject);
		if (other.gameObject.tag == "Player" && isEnabled)
		{
			SceneManager.LoadScene(2);
		}
	}
}
