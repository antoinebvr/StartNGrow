using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManagerMenu : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform QuitRectTransform;
    public float fadeTime = 2f;
    public float bounceTime = 0.25f;
    public float longBounceTime = 1.5f;
    public CanvasGroup canvasGroup;
    public List<GameObject> numbers = new List<GameObject>();
    public Button startButton;
    public Button volumeButton;
    public Sprite volumeON;
    public Sprite volumeOFF;

    private void Start()
    {
        QuitRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);
    }
    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine("NumbersAnimations");
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
    }

    public void QuitPanelFadeIn()
    {
        QuitRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        QuitRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
    }

    public void QuitPanelFadeOut()
    {
        QuitRectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        QuitRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }

    IEnumerator NumbersAnimations()
    {
        foreach (var number in numbers)
        {
            number.transform.localScale = Vector3.zero;
        }
        foreach (var number in numbers)
        {
            number.transform.DOScale(1f, bounceTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator StopInfiniteStartButtonLoop()
    {
        yield return new WaitForSeconds(5);
    }

    public void StartButtonAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(startButton.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).SetDelay(0.1f));
        sequence.Append(startButton.transform.DOScale(Vector3.one, 0.5f));
        sequence.SetLoops(-1, LoopType.Restart);
        StartCoroutine("StopInfiniteStartButtonLoop");
        sequence.SetLoops(3);

    }

    public void SwitchSound()
    {
        volumeButton.GetComponent<Button>();

        if (volumeButton.image.sprite == volumeON)
        {
            volumeButton.image.sprite = volumeOFF;
            AudioListener.pause = true;
        }
        else
        {
            volumeButton.image.sprite = volumeON;
            AudioListener.pause = false;
        }

    }
}
