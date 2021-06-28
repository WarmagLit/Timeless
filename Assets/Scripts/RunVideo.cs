using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunVideo : MonoBehaviour
{
	public PlayScript playscript1;
	public Animator camAnim;
	public PrototypeHeroDemo heroScript;
	public DialogueTrigger dialtrig;

	public NextScene1 door;

	[SerializeField] GameObject dialogueCanvas;
	private bool firstTime = true;

	private void Update()
	{
		ShootingHandle();
	}

	private IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(other.gameObject);
		if (other.gameObject.tag == "Player" && firstTime)
		{
			firstTime = false;
			playscript1.Run();

			camAnim.SetBool("Cutscene1", true);
			heroScript.enabled = false;
			heroScript.movementScript.MoveHero(0);
			
			yield return new WaitForSeconds(25);

			dialogueCanvas.SetActive(true);
			dialtrig.TriggerDialogue();

			yield return new WaitForSeconds(5);

			heroScript.enabled = true;

			StopCutscene();
			door.isEnabled = true;
		}
	}

	private void ShootingHandle()
	{
		if (Input.GetButtonDown("Use"))
		{
			playscript1.Stop();
		}
	}

	void StopCutscene() {
		camAnim.SetBool("Cutscene1", false);
	}
}
