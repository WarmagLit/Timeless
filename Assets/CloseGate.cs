using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{

    private bool firstTime = true;
    public Animator animator;
    

    private void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(other.gameObject);
		if (other.gameObject.tag == "Player" && firstTime)
		{
			firstTime = false;
			
            animator.SetTrigger("Close");
		}
	}
}
