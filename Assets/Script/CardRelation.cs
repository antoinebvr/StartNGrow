using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardRelation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<CardData> ListCard;
    // permet de lancer la fonction Relation permettant d'activer les cartes 

    public void lancement()
    {
   //penser à retirer le switch et le for useless 
            for (int i = 1; i < 16; i++)
            {
                Relation(i);
            }
    }
    //Permet de définir les relations entre chaque carte, pour qu'une carte soit active il faut que une ou plusieurs autre le soi déjà
    public void Relation(int i)
    {
       
        switch(i)
        {
            case 1:
                foreach(CardData cards in ListCard)
                { 
                    if((cards.id == 8 || cards.id == 9||cards.id == 10) && cards.actif == true && ListCard[0].quantite !=0)
                    {
                        ListCard[0].actif = true;
                    }
                }
                break;
            case 2:
                foreach (CardData cards in ListCard)
                {
                    if (cards.id == 7 && cards.actif == true && ListCard[1].quantite != 0)
                    {
                        ListCard[1].actif = true;
                    }
                }
                break;

            case 3:
                foreach (CardData cards in ListCard)
                {
                    if (cards.id == 7 && cards.actif == true && ListCard[2].quantite != 0)
                    {
                        ListCard[2].actif = true;
                    }
                }
                break;
            case 4:
                foreach (CardData cards in ListCard)
                {
                    if (cards.id == 7 && cards.actif == true && ListCard[3].quantite != 0)
                    {
                        ListCard[3].actif = true;
                    }
                }
                break;
            case 5:
                foreach (CardData cards in ListCard)
                {
                    if ((cards.id == 11 || cards.id == 12) && cards.actif == true && ListCard[4].quantite != 0)
                    {
                        ListCard[4].actif = true;
                    }
                }
                break;
            case 6:
                foreach (CardData cards in ListCard)
                {
                    if ((cards.id == 11 || cards.id == 12) && cards.actif == true && ListCard[5].quantite != 0)
                    {
                        ListCard[5].actif = true;
                    }
                }
                break;
            case 7:
                if(ListCard[6].quantite != 0)
                {
                    ListCard[6].actif = true;
                }
                break;
            case 8:
                if (ListCard[7].quantite != 0)
                {
                    ListCard[7].actif = true;
                }
                break;
            case 9:
                if (ListCard[8].quantite != 0)
                {
                    ListCard[8].actif = true;
                }
                break;
            case 10:
                foreach (CardData cards in ListCard)
                {
                    if ((cards.id == 5 || cards.id == 6) && cards.actif == true && ListCard[9].quantite != 0)
                    {
                        ListCard[9].actif = true;
                    }
                        
                }
                break;
            case 11:
                if (ListCard[10].quantite != 0)
                {
                    ListCard[10].actif = true;
                }
                break;
            case 12:
                if (ListCard[11].quantite != 0)
                {
                    ListCard[11].actif = true;
                }
                break;
            case 13:
                foreach (CardData cards in ListCard)
                {
                    if (cards.id == 1 && cards.actif == true && ListCard[12].quantite != 0)
                    {
                        ListCard[12].actif = true;
                    }
                }
                break;
            case 14:
                foreach (CardData cards in ListCard)
                {
                    if ((cards.id == 5 || cards.id == 6) && cards.actif == true && ListCard[13].quantite != 0)
                    {
                        ListCard[13].actif = true;
                    }
                }
                break;
            case 15:
                foreach (CardData cards in ListCard )
                {
                    if ((cards.id == 8 || cards.id == 9 || cards.id == 10) && cards.actif == true && ListCard[14].quantite != 0)
                    {
                        ListCard[14].actif = true;
                    }
                }
                break;
        }
    }
    private void OnEnable()
    {
        for (int i=0; i<ListCard.Count; i++)//+1
        {
            ListCard[i].actif = false;
        }
    }
}

