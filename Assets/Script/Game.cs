using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Affichage = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public RectTransform ScoreRectTransform;
    public float fadeTime = 2f;
    public MonthTurn Month;
    public GameObject PanelTransparency;
    //Limite le nombre de tour
    //permet d'afficher le score quand le nombre de tour limite est arriv�
    public void ScoreAffichage()
    {
        for (int i = 1; i < 9; i++) 
        {
            if (SceneManager.GetActiveScene().name == "Scenario"+i)
            {
                switch(i)
                {
                    case 1:
                        if (Month.MonthValue == 3)//3
                        {
                            CalculScore(i);
                            Affichage.text = Score.ToString() + " pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                            
                        }
                        break;
                    case 2:
                        if (Month.MonthValue == 5)
                        {
                            CalculScore(i);
                            Affichage.text = Score.ToString() + " pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 3:
                        if (Month.MonthValue == 5)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 4:
                        if (Month.MonthValue == 9)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 5:
                        if (Month.MonthValue == 10)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 6:
                        if (Month.MonthValue == 6)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 7:
                        if (Month.MonthValue == 7)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;
                    case 8:
                        if (Month.MonthValue == 2)
                        {
                            CalculScore(i);
                            Affichage.text  = Score.ToString() + "pts";
                            ScoreRectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
                            ScoreRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash);
                            PanelTransparency.SetActive(true);
                        }
                        break;

                }
            }

        }
        
    }
    public CashFlow cash;
    public int Score=0;
    int ratioMoney = 1;
    int ScoreObjectif =500;
    public Objectif objectif;
    int ConditionRemplie = 0;
    public TextMeshProUGUI Affichage;

    //permet de calculer le score du joueur !
    public void CalculScore(int i)
    {
        switch(i)
        {
            case 1:
                Score = cash.MoneyTemporaire * ratioMoney;
                for(int j = 0; j < 50; j++)
                {
                    if(objectif.condition[1,j] == true)
                    {
                        ConditionRemplie++;
                    }
                }
                Score += ScoreObjectif*ConditionRemplie;
                break;          
        }
    }
    //  Permet de revenir au choix des scenarios (bouton ecran score)
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    private void OnEnable()
    {
          
    }
}
