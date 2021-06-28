using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public PrototypeHeroDemo mainHero;
    private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Player")
		{
			mainHero.TakeDamage(float.MaxValue);
		}
	}
}
