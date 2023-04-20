using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;
using TMPro;

public class Objectif : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public TextMeshProUGUI[] interrogation;
    public bool[,] condition = new bool[50, 50];
    public AnimationCurve curve;
    public CardData[] card;
    private RectTransform rectTransform;
    public bool[] actif;
    public Image[] coche;

    private void Start()
    {
        //  TextMeshProUGUI Affichage = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                condition[i, j] = false;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            Color newColor = text[i].color;
            newColor.a = startAlpha;
            text[i].color = newColor;

        }

    }


    private void Update()
    {
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (condition[i, j] && actif[j - 1] == false)
                {
                    ObjectifAnimation(j - 1);

                }
            }
        }
    }

    public float duration = 1.5f;
    private float elapsedTime = 0.0f;
    private float startAlpha = 0;
    private float endAlpha = 1.0f;


    public void ObjectifAnimation(int i)
    {
        interrogation[i].alpha = startAlpha;
        elapsedTime += Time.deltaTime;
        float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
        Color newColor = text[i].color;
        Color ImageColor = coche[i].color;
        newColor.a = currentAlpha;
        ImageColor.a = currentAlpha;
        text[i].color = newColor;
        coche[i].color = newColor;
        if (elapsedTime >= duration)
        {
            actif[i] = true;
            elapsedTime = 0.0f;
            //startAlpha = endAlpha;
            //condition[i,i] = false;
        }
    }

    public void ConditionObjectif()
    {
        for (int i = 1; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().name == "Scenario" + i)
            {
                foreach (CardData cards in card)
                {
                    switch (i)
                    {
                        case 1:
                            if (cards.id == 2 && cards.quantite > 0 && condition[1, 1] == false)
                            {
                                condition[1, 1] = true;
                                // ObjectifAnimation(i);
                            }
                            if (cards.id == 7 && cards.quantite > 0 && condition[1, 2] == false)
                            {
                                condition[1, 2] = true;
                                //  ObjectifAnimation(i);
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                    }
                }
            }
        }
    }
}


