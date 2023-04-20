using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.ObjectChangeEventStream;

public class MonthTurn : MonoBehaviour
{
    public TextMeshProUGUI Month;
    public int MonthValue = 0;
    public CashFlow CashTurn;
    public List<CardData> builds;
    public List<int> quantitecreer;
    public List<int> time;
    public List<int> waiting;

    public string[] roundNumber;
    public TMP_Text roundText;
    public float fadeTime = 2;
    public int i = 0;
    public int roundMax;

    
    public void Start()
    {
        roundText.GetComponent<RectTransform>().transform.position = new Vector3(1000f, 1500f, 0f);
    }
 
    public void NextMonth()
    {
        MonthValue++; 
        CashTurn.money = CashTurn.MoneyTemporaire;
        CashTurn.verifid = 0;
        CashTurn.verif = true;
        Month = GetComponent<TextMeshProUGUI>();
        Month.text = MonthValue.ToString() + "/" + roundMax + " Round";
        ShowRoundNumber();   
    }

    

    public void ShowRoundNumber()
    {
        roundText.text = roundNumber[i];
        i++;
        roundText.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, 1500f, 0f);
        roundText.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutFlash).OnComplete(() =>
        {
            roundText.DOColor(new Vector4(255, 255, 255, 0), 2).OnComplete(() =>
            {
                roundText.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, 1500f, 0f);
                roundText.DOColor(new Vector4(255, 255, 255, 255), 0);
            });
        });
    }

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(2);
    }
    
    public void StartAnimCoroutine()
    {
        StartCoroutine("WaitAnim");
    }
    



}

