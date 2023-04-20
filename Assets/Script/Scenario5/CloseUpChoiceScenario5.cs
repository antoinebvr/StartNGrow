using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CloseUpChoiceScenario5 : MonoBehaviour
{
    public string supplySelected;
    public TMP_Text textToDisplay;
    public GameObject gris;
    public GameObject boosterCursor;
    public GameObject matureZoneCursor;
    public UiManagerScenarios uiManager;
    public bool selectedOnce = false;
    private int x = 0;
    private int y = 0;

    Tween matureZoneTween;
    Tween boosterTween;

    public GameObject animationStart;
    public bool matureZoneChoice = false;
    public bool boosterChoice = false;

    void Update()
    {
        if (selectedOnce == true && x == 0)
        {
            x++;
            uiManager.StartButtonAnimation();
        }
    }

    public void BoosterChoice()
    {
        matureZoneTween.Kill();
        matureZoneCursor.transform.DOLocalMoveY(250, 0.25f, false);
        
        textToDisplay.DOFade(255, 0);
        supplySelected = new string("Booster selected");
        textToDisplay.text = supplySelected;
        gris.SetActive(false);
        textToDisplay.DOFade(0, 3);
        selectedOnce = true;
        boosterChoice = true;
        matureZoneChoice = false;

        boosterTween = boosterCursor.transform.DOLocalMoveY(-140 , 0.5f, false).SetLoops(-1, LoopType.Yoyo);
    }

    public void MatureZoneChoice()
    {
        boosterTween.Kill();
        boosterCursor.transform.DOLocalMoveY(-185, 0.25f, false);

        textToDisplay.DOFade(255, 0);
        supplySelected = new string("Mature Zone selected");
        textToDisplay.text = supplySelected;
        gris.SetActive(false);
        textToDisplay.DOFade(0, 3);
        selectedOnce = true;
        matureZoneChoice = true;
        boosterChoice = false;

        matureZoneTween = matureZoneCursor.transform.DOLocalMoveY(295, 0.5f, false).SetLoops(-1, LoopType.Yoyo);
    }

    public void startScenario()
    {
        if(boosterChoice)
        {
            uiManager.FadeInBadAnswer();
        }
        else if (matureZoneChoice)
        {
            animationStart.SetActive(true);
        }
    }
}
