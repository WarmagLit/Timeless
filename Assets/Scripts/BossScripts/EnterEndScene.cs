using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterEndScene : MonoBehaviour
{
    [SerializeField] GameObject endSceneCanvas;
    [SerializeField] GameObject buttonCanvas;
    [SerializeField] Animator blackPanelAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PrototypeHeroDemo hero = collision.transform.GetComponent<PrototypeHeroDemo>();
        if (hero != null)
        {
            hero.enabled = false;
            hero.movementScript.MoveHero(0);
            blackPanelAnimator.SetTrigger("StartScene");
            StartCoroutine(StartFinalScene());
        }
    }

    private IEnumerator StartFinalScene()
    {
        yield return new WaitForSeconds(1.8f);
        endSceneCanvas.SetActive(true);
        buttonCanvas.SetActive(true);
        FindObjectOfType<PrototypeHeroDemo>().gameObject.SetActive(false);
    }
}
