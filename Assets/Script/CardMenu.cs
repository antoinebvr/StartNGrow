using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;
using TMPro;
using static UnityEditor.ObjectChangeEventStream;
using System.Security;
using UnityEngine.SceneManagement;
using UnityEditor.Tilemaps;
using Mono.Cecil.Cil;
using DG.Tweening;


public class CardMenu : MonoBehaviour
{
    public CardLimitation Limit;
    public CardData cardData;
    public int a;
    GameObject gris;
    public GameObject[] Grise;
    // Start is called before the first frame update
    void OnEnable()
    {
        DOTween.SetTweensCapacity(5000, 50);
        CardLimit();
        foreach (CardData card in builds)
        {      
                card.isSelected = false;
        }
        //gris = GetComponentInChildren<GameObject>(true);
    }
    // Update is called once per frame
    void LateUpdate()
    {

    }
    public CashFlow Cash;
    public CardAnimation CardAnimation;

    // Permet de selectionner/ deselectionner la carte sur laquelle on clique 
    public void ClickImg()
    {

        if (Cash.verifid != cardData.id && Cash.verif == true)
        {
            CashGestion();
            CardAnimation.focusCard();
        }
        else if (Cash.verifid != cardData.id && Cash.verif == false)
        {
            Cash.MoneyTemporaire = Cash.money;
            //Actif();
            CardAnimation.stopFocusCard();
            foreach (CardData cards in builds)
            {
                if (Cash.verifid == cards.id) { cards.quantite--; }
            }
            if (a < 0) { a++; }
            AnnuleQuantity();
            CashGestion();
            //Actif();
            CardAnimation.focusCard();
        }

        else if (Cash.verifid == cardData.id || Cash.verif == false)
        {
            
            Cash.MoneyTemporaire = Cash.money;
            Cash.verifid = 0;
            //Actif();
            Cash.verif = true;
            cardData.quantite--;
            AnnuleQuantity();
            CardAnimation.stopFocusCard();
        }

    }
    // permet de diminuer le cout de la carte de l'argent du joueur
    public void CashGestion()
    {

        Cash.money = Cash.MoneyTemporaire;
        Cash.MoneyTemporaire = Cash.MoneyTemporaire - cardData.cardCost;
        Cash.verifid = cardData.id;
        Cash.verif = false;
        cardData.quantite++;
        Quantity();



    }

    public int quantityTemporaire;
    public MonthTurn Mois;
    public List<CardData> builds;
    public void Quantity()
    {
        do
        {
            a++;
        }
        while (Mois.time[a] != 0 && Mois.waiting[a] != 0);
        Mois.time[a] = cardData.cardMonth;//BASE
        Mois.waiting[a] = cardData.id;//BASE
    }
    public void AnnuleQuantity()
    {
        if (Mois.waiting[a] != 0)
        {
            Mois.time[a] = 0;
            Mois.waiting[a] = 0;
            a--;
        }
    }

    public void QuantityTour()
    {
        for (int b = 0; b < Mois.time.Count; b++)//+1
        {

            if (Mois.time[b] > 0)
            {
                Mois.time[b]--;
            }
            if (Mois.time[b] == 0 && Mois.waiting[b] != 0) //carteattente =id de la carte 
                                                           // time = le nbr de tour qui reste avant construction de la structure
            {
                foreach (CardData cards in builds)
                {
                    if (cards.id == Mois.waiting[b])
                    {
                        Mois.quantitecreer[cards.id]++;
                        Mois.waiting[b] = 0;
                    }
                }
            }
        }
    }

    public void Temporaire()
    {
        quantityTemporaire = cardData.quantite;
    }
    //Viens "griser" les cartes qui ne peuvent etre utilis�
    public void CardLimit()
    {
        CalculBlue();
        int x = 0;
        for (int i = 1; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().name == "Scenario" + i)
            {
                switch (i)// lance le code qui corresponds au scenario actuel 
                {
                    case 1:
                        x = 3;
                        CardLimit2(x);
                        CardLimit3();
                        break;
                    case 2:
                        x = 5;
                        CardLimit2(x);
                        break;
                }
            }
        }

    }
    public void  CardLimit2(int i)
    {
        foreach (CardData cards in builds)
        {
            gris = null;
            gris=GetChildWithCodeAndName(this.cardData.name);//this.cardData
            // GameObject gris = gameObject.GetComponentInChildren<GameObject>(name=="gris");
            //gris.GetComponentInChildren<GameObject>(name == "gris");
            if ((Cash.MoneyTemporaire < this.cardData.cardCost || this.cardData.cardMonth > i))
            {
                Limit.ActivationLimit(cardData.id, gris); //activation grisement la carte //this.cardData.id//gris
            }
            else 
                {
                 //  Limit.DeactivationLimit(cardData.id,gris); //desactivation Grisement
                }
                GameObject gris2 = GetChildWithCodeAndName(cards.name);
                if (Cash.MoneyTemporaire < cards.cardCost || cards.cardMonth > i)
                {
                    Limit.ActivationLimit(cards.id, gris2);
                }
                if (Cash.MoneyTemporaire >= cards.cardCost && cards.cardMonth <= i) // store qui pop why?
                {
                    Limit.DeactivationLimit(cards.id, gris2);
                }
               
            

        }
    }
    public int Blue;
    public void CalculBlue() //A METTRE DANS SKIP
    {
        int tempo=Blue;
        foreach(CardData cards in builds)
        {
            if(cards.id == 1 || cards.id == 2 || cards.id == 15 || cards.id == 4)
            {
                Blue-=cards.quantite;
                if(cards.id == 15)
                {
                    Blue -= cards.quantite*2;
                }
                else{ Blue -= cards.quantite; }
                if(Blue !=0)
                {
                    Blue = tempo;
                }
            }
        }
    }
    public void CardLimit3()
    {
        foreach (CardData cards in builds)
        {
            if(cards.id == Cash.verifid) {
                gris = null;
                gris = GetChildWithCodeAndName(cards.name);
                switch (cards.id)
        {
            case 1:
                if( Blue == 0)
                {
                            Limit.ActivationLimit(cards.id, gris);//active grisement
                }
                break;
            case 2:
                Blue = 5;//TEST
                if ( Blue == 0)
                {
                    Limit.ActivationLimit(cards.id, gris);//active grisement
                }
                break;
            case 3:
                if (cards.quantite == 1 )
                {
                    Limit.ActivationLimit(cards.id, gris);//active grisement
                }
                break;
            case 4:
                if (cards.quantite == 1 )
                {
                    Limit.ActivationLimit(cards.id, gris);//active grisement
                }
                break;
            case 5:
                //if (cards.quantite == 1 )
                //{
                    Limit.ActivationLimit(cards.id, gris);// Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 6:
              //  if (cards.quantite == 1 )
                //{
                  Limit.ActivationLimit(cards.id,gris);//Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 7:
                //if (cards.quantite == 1 )
                //{
                    Limit.ActivationLimit(cards.id,gris);// Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 8:
                //if (cards.quantite == 1 )
               // {
                    Limit.ActivationLimit(cards.id,gris);// Limit.ActivationLimit(Cash.verifid);//active grisement
             //   }
                break;
            case 9:
               // if (cards.quantite == 1 )
                //{
                    Limit.ActivationLimit(cards.id,gris);//Limit.ActivationLimit(Cash.verifid);//active grisement
               // }
                break;
            case 10:
               // if (cards.quantite == 1 )
             //   {
                    Limit.ActivationLimit(cards.id,gris);//Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 11:
                //if (cards.quantite == 1 )
                //{
                    Limit.ActivationLimit(cards.id,gris);//Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 12:
                //if (cards.quantite == 1 )
                //{
                    Limit.ActivationLimit(cards.id,gris);//Limit.ActivationLimit(Cash.verifid);//active grisement
                //}
                break;
            case 13:
                //if (cards.quantite == 1 && cards.id == 13)
                //{
                    Limit.ActivationLimit(cards.id,gris);//active grisement
                //}
                break;
            case 14:
                //if (cards.quantite == 1 && cards.id == 14)
                //{
                    Limit.ActivationLimit(cards.id,gris);//active grisement
                //}
                break;
            case 15:
                  //  if (this.cardData.quantite == 2 && cards.id == 15)//this.cardData
                //{
                    Limit.ActivationLimit(cards.id,gris);//active grisement
                //}
                break;
            }
            }
        }
    }
    //GameObject child;
    GameObject GetChildWithCodeAndName(string code)
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.GetChild(0).name =="Gris")//.name="" gameObject.name == "gris")//child.name == code && 
            {
                return child.GetChild(0).gameObject;
            }
        }
        return null;
    }
    public GameObject[] GetSelected;
    public CardRelation game;

    public void SelectCard()
    {
            foreach (CardData card in builds)
            {
                if (card.id == Cash.verifid)// game.Activation && game.Activation != 0)
                {
                    GetSelected[card.id - 1].transform.DOMoveY(350, 0.25f, false);
                }
                
            }
    }
    


  /*  public void Actif()
    {
        if (Cash.verifid !=0)
         game.Activation = Cash.verifid; 
        else 
         game.Activation = 0;
    }
  */
}


