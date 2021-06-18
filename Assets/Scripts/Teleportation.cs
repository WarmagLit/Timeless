using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

	public GameObject Portal;
	public GameObject Player;
	public float WaitForSec = 0.5f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(Teleport());
		}
	}


	IEnumerator Teleport()
	{
		yield return new WaitForSeconds(WaitForSec);
		Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
	}
}