using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Skip : MonoBehaviour
{

    // références skip
    public ConstructionPlace constructionPlace;
    public CardManager cardManager;
    public Game game;
    public MonthTurn monthTurn;
    public CardMenu cardMenu;
    public CardRelation cardRelation;
    public CashFlow cashFlow;
    public Objectif objectif;
    public Progress_Bar bar;


    // autres références
    public UiManagerScenarios uiManager;

    public void SkipConfirm()
    {
        if (cashFlow.verifid != 0)
        {
            ForceSkip();
        }
        else if (cashFlow.verifid == 0)
        {
            uiManager.FadeInSkipConfirm();
        }
    }

    public void ForceSkip()
    {
        bar.BarProgress();
        constructionPlace.ClickBack();
        //bar.BarProgress();
        cardMenu.CardLimit();
        objectif.ConditionObjectif();
        constructionPlace.PlayACard();
        cardManager.DrawBackBlueCard();
        cardManager.DrawBackGreenCard();
        cardManager.DrawBackRedCard();
        cardManager.DrawBackYellowCard();
        game.ScoreAffichage();
        monthTurn.NextMonth();
        cardMenu.QuantityTour();
        cardRelation.lancement();
        cashFlow.Profit();
    }
    public TextMeshProUGUI skip;
    public void ChangeSkipConfirm()
    {
        if(cashFlow.verifid != 0)
        {
            //skip = GetComponent<TextMeshProUGUI>();
            skip.text = "Confirm";
        }
        else
        {
            skip.text = "Skip";
        }
    }
    public void Update()
    {
        ChangeSkipConfirm();
    }
}
