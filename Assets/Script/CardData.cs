using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Deca Game/Card Data")]
public class CardData : ScriptableObject
{
    public int id;
    public string cardName;
    public string cardDescription;
    public int cardProfit;
    public int cardMonth;
    public int cardCost;
    public int Multiplier;
   // public GameObject cardImage;
   // public Sprite cardSprite;
    public int quantite;
    public bool actif;
    public bool isSelected;
    //public float calculProfit;
    //public int quantitecreer;
    //public int time;
    //CashFlow Cash;

    /*public CashFlow Cash;
    public void ClickImg()
    {
        cardImage.GetComponent<Image>();
        Cash.MoneyTemporaire = Cash.MoneyTemporaire - cardCost;
    }*/
}
