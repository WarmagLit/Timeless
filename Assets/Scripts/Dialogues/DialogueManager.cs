using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public Animator animator;
	public PrototypeHeroDemo heroScript;

	private Queue<string> sentences;

	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		heroScript.enabled = false;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		Debug.Log(sentences.Count);
		if (sentences.Count == 0)
		{
			StartCoroutine(EndDialogue());
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
		
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		yield return new WaitForSeconds(1.2f);
		heroScript.enabled = true;
	}
}
