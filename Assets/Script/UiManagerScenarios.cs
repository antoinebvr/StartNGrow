using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManagerScenarios : MonoBehaviour
{

    // attributs pour animations des panels
    public RectTransform ScenarioRectTransform;
    public RectTransform QuitRectTransform;
    public RectTransform ScoreRectTransform;
    public RectTransform SkipRectTransform;
    public RectTransform BadAnswerRectTransform;
    public float fadeTime = 2f;

    // attributs pour le bouton du son
    public Button volumeButton;
    public Sprite volumeON;
    public Sprite volumeOFF;

    // attributs pour l'animation du bouton scenario & start
    public Button scenarioButton;
    public Button startButton;

    // bouton skip
    public GameObject transparencyPanel;
    public GameObject blurGV;
    public GameObject skipButton;

    // bouton start
    public GameObject startTransparencyPanel;
    public GameObject startBlurGV;

    // positionne les panneaux au lancement de la scène
    private void Start()
    {
        ScenarioRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);
        QuitRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);
        ScoreRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);
        SkipRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);
        BadAnswerRectTransform.transform.position = new Vector3(1000f, -1000f, 0f);

        ScenarioButtonAnimation();
        
    }

    // apparition et disparition du panneau scénario
    public void FadeInScenario()
    {
        ScenarioRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        ScenarioRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
    }
    public void FadeOutScenario()
    {
        ScenarioRectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        ScenarioRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }

    // apparition et disparition du panneau retour au menu principal
    public void FadeInMenu()
    {
        QuitRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        QuitRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
    }
    public void FadeOutMenu()
    {
        QuitRectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        QuitRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }

    // apparition du panneau de score
    public void FadeInScore()
    {
        ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutBounce);
    }

    // apparition et disparition du panneau skip confirm
    public void FadeInSkipConfirm()
    {
        SkipRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        SkipRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
        blurGV.SetActive(true);
        transparencyPanel.SetActive(true);
    }
    public void FadeOutSkipConfirm()
    {
        SkipRectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        SkipRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }

    // apparition et disparition du panneau bad answer
    public void FadeInBadAnswer()
    {
        BadAnswerRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        BadAnswerRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
        startBlurGV.SetActive(true);
        startTransparencyPanel.SetActive(true);
    }
    public void FadeOutBadAnswer()
    {
        BadAnswerRectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        BadAnswerRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
    }

    // retour au menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // active/désactive le son
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

    IEnumerator StopInfiniteScenarioButtonLoop()
    {
        yield return new WaitForSeconds(5);
    }

    // animation du bouton scenario
    public void ScenarioButtonAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(scenarioButton.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).SetDelay(0.1f));
        sequence.Append(scenarioButton.transform.DOScale(Vector3.one, 0.5f));
        sequence.SetLoops(-1, LoopType.Restart);  
        // StartCoroutine("StopInfiniteScenarioButtonLoop");
        // sequence.SetLoops(3); 
    }






    // IEnumerator StopInfiniteStartButtonLoop()
    // {
    //     yield return new WaitForSeconds(5);
    // }



    public void StartButtonAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(startButton.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f).SetDelay(0.1f));
        sequence.Append(startButton.transform.DOScale(Vector3.one, 0.5f));
        sequence.SetLoops(-1, LoopType.Restart);
        // StartCoroutine("StopInfiniteStartButtonLoop");
    }
}
