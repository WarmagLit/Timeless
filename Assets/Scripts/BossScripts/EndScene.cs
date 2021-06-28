using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] Sprite[] dialogueImages;
    [SerializeField] Animator blackPanelAnimator;
    [SerializeField] GameObject gameOverCanvas;

    private Image image;
    private int currentImageIndex = 1;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void NextImage()
    {
        if (currentImageIndex < dialogueImages.Length)
        {
            image.sprite = dialogueImages[currentImageIndex];
            currentImageIndex++;
        }
        else
        {
            blackPanelAnimator.SetTrigger("EndGame");
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.8f);
        gameOverCanvas.SetActive(true);
    }
}
