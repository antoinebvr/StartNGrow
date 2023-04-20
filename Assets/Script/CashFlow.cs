using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CashFlow : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {


    }
    public TextMeshProUGUI Cash;
    public int money;
    public int MoneyTemporaire;
    public bool verif;
    public int verifid = 0;

    public void Money()
    {
        //string txt = "Money : ";
        // string txt2 = " \nProfit : ";
        Cash.text = MoneyTemporaire.ToString();// + txt2 + profit.ToString();
    }

    public CardData[] cards;
    private int profit;

    public void ProfitTemporaire() // n'est pas utilisé ????
    {
        profit = 0;
        foreach (CardData card in cards)
        {
            if (card.quantite != 0 && card.actif == true)
            {
                if (card.cardProfit != 0)
                {
                    profit += card.cardProfit * card.quantite * card.Multiplier;
                }

                else
                {
                    profit *= card.quantite * card.Multiplier;
                }
            }
        }
    }
    public MonthTurn Mois;
    // permet de calculer le profit du joueur 
   
    public void Profit()
    {
        int variable = 0;
        profit = 0;
        foreach (CardData card in cards)
        {     
            if (Mois.quantitecreer[card.id] != 0 && card.actif == true)
            {
                if (card.cardProfit != 0)
                {
                    profit += card.cardProfit * Mois.quantitecreer[card.id]; //* pas besoin du if en théorie
                }
                profit *= card.Multiplier;
            }
            variable += Mois.quantitecreer[card.id];
        }
        if (variable == 0) { profit = 0; }
        MoneyTemporaire += profit;
        Money();
    }

    //OnEnable permet de lancer une fonction au lancement du jeu, ici on initialise toute les quantités de chaque carte à 0
    private void OnEnable()
    {
        foreach (CardData card in cards)
        {
            Cash = GetComponent<TextMeshProUGUI>();
            card.quantite = 0;
        }
    }
    
    
}
