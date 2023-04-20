using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Bar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < progressBarStore.Length; j++) { progressBarStore[j].value = 0; }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] barSwo;//4
    public GameObject[] barStore;//1
    public Image[] barPopup;//2
    public GameObject[] barCacCar540;//5
    public GameObject[] barCacCarOffer;//6
    public MonthTurn month;
    public ConstructionPlace build;
    public Slider[] progressBarSwo;
    public Slider[] progressBarStore;
    public Slider[] progressBarPopup;
    public Slider[] progressBarCacCar540;
    public Slider[] progressBarCacCarOffer;
    public CardData[] builds;
    public Image[] spritePoufPopup;
    public Image[] spritePoufStore;
    public Image[] spritePoufCacCar540;
    public Image[] spritePoufCacCarOffer;
    public Image[] spritePoufSwo;
    public int[] spriteCount;
    public Sprite[] Pouff;
    public Image[] listSwo;
    public Image[] listCacCar540;
    public Image[] listCacCarOffer;
    // public CanvasGroup builded;
    float calcul1;
    float calcul2;
    public int[] waitbar;
    public int x;
    public int y;
    public void BarProgress()
    {
        for(int i = 0; i < month.waiting.Count; i++)
        {
            if(month.waiting[i] == 4 || month.waiting[i]==5 || month.waiting[i] ==6 || month.waiting[i] == 1 || month.waiting[i] ==2 || waitbar[i] !=0)
            {
               /* if(month.waiting[i] != 0)
                {
                    x = month.waiting[i];
                }*/
                if (waitbar[i] != 0)
                {
                    x = waitbar[i];
                }
                else if (month.waiting[i] != 0)
                {
                    x = month.waiting[i];
                }
                switch (x)
                {
                    case 1:
                        waitbar[i] = 1;
                        for (int j = 0; j < barStore.Length; j++)
                        {
                            if (progressBarStore[j].interactable == true)
                            {
                                foreach (CardData cards in builds)
                                {
                                    if (cards.id == x && progressBarStore[j].value !=1)
                                    {
                                        calcul1=100/cards.cardMonth; calcul2 = cards.cardMonth - month.time[i];
                                        progressBarStore[j].value = calcul1*calcul2;
                                    }
                                    if (progressBarStore[j].value == 100 || progressBarStore[j].value ==99) { waitbar[i] = 0; Pouf(progressBarStore[j], x); }
                                    
                                }
                            }
                        }
                        break;
                    case 2:
                        int y;
                            waitbar[i] = 2;
                            foreach (CardData cards in builds)
                            {
                                if(cards.quantite == 0) { y = 0; } else { y = 1; }
                                if(cards.id == 2)
                            {
                                for (int j = 0; j <= cards.quantite-y; j++)
                                {
                                    if (cards.id == x && progressBarPopup[j].value !=1)
                                    {
                                        calcul1=100/cards.cardMonth; calcul2 = cards.cardMonth - month.time[i];
                                        progressBarPopup[j].value = calcul1*calcul2;
                                    }
                                    if (progressBarPopup[j].value == 100 || progressBarPopup[j].value ==99) { waitbar[i] = 0; Pouf(progressBarPopup[j], x); }
                                }
                            }
                        }
                        break;
                    case 4:
                        waitbar[i] = 4;          
                        foreach (CardData cards in builds)
                        {
                          //  for (int j = 0; j < cards.quantite - 1; j++)
                          //  {
                                if (cards.id == month.waiting[i] && progressBarSwo[0].value != 1)
                                    {
                                        progressBarSwo[0].value = 100;
                                    }
                                    if (progressBarSwo[0].value == 100) { waitbar[i] = 0; Pouf(progressBarSwo[0], x); }
                             //   }
                        }

                        break;
                    case 5:
                        waitbar[i] = 5;
                        foreach (CardData cards in builds)
                       {
                            for (int j = 0; j < cards.quantite - 1; j++)
                            {
                                if (cards.id == month.waiting[i] && progressBarCacCar540[j].value !=1)
                                    {
                                    calcul1 = 100 / cards.cardMonth; calcul2 = cards.cardMonth - month.time[i];
                                    progressBarCacCar540[j].value = calcul1 * calcul2;
                                    }
                                if (progressBarCacCar540[j].value == 100 || progressBarCacCar540[j].value == 99) { waitbar[i] = 0; Pouf(progressBarCacCar540[j], x); }
                            }
                        }
                        break;
                    case 6:
                        waitbar[i] = 6;
                        foreach (CardData cards in builds)
                        {
                            for (int j = 0; j < cards.quantite - 1; j++)
                            {
                                if (cards.id == month.waiting[i] && progressBarCacCarOffer[j].value != 1)
                                {
                                    calcul1 = 100 / cards.cardMonth; calcul2 = cards.cardMonth - month.time[i];
                                    progressBarCacCarOffer[j].value = calcul1 * calcul2;
                                }
                                if (progressBarCacCarOffer[j].value == 100 || progressBarCacCarOffer[j].value == 99) { waitbar[i] = 0; Pouf(progressBarCacCarOffer[j], x); }
                            }
                        }
                        break;
                }
            }

        }

    }
    public void Pouf(Slider progressbar,int waiting)
    {
        if(progressbar.value == 100 || progressbar.value ==99)
        {
            int INDEX = build.indexStore + build.indexPopup;
            switch(waiting)
            {
                case 1:
                    AnimatePouf(spritePoufStore[INDEX], spriteCount, Pouff, INDEX, build.stores, build.TemporairesStores, progressbar, build.placebuild, build.indexStore) ; //build.placebuildStore);
              
                    break;
                case 2:
                    AnimatePouf(spritePoufPopup[INDEX-1], spriteCount, Pouff,INDEX, build.popups, build.TemporairesPopUp, progressbar, build.placebuild, build.indexPopup);//build.placebuildPopUp); //build.indexPopup-1
                    break;
                case 4:
                    //listSwo[0]=build.swoPartner;
                    //listSwo[1] = build.swoPartner;
                    //listSwo[2] = build.swoPartner;
                    y++;
                    AnimatePouf(spritePoufSwo[INDEX], spriteCount, Pouff, INDEX, listSwo, build.TemporairesSwo, progressbar, build.placebuild, 10); //build.placebuildSwo);
                    break;
                case 5:
                    listCacCar540[0] = build.CacCaR540;
                    AnimatePouf(spritePoufCacCar540[build.indexCacCar], spriteCount, Pouff, 0, listCacCar540, build.cacCars, progressbar, build.placebuild, 10); //build.placebuildCacCar540);
                    break;
                case 6:
                    listCacCarOffer[1] = build.CacCarFullOffer;
                    AnimatePouf(spritePoufCacCar540[build.indexCacCar], spriteCount, Pouff, 1, listCacCarOffer, build.cacCars, progressbar, build.placebuild, 10); //build.placebuildCacCarFull);
                    break;
            }    
            
        }
    }
    void AnimatePouf(Image image, int[] spriteCount, Sprite[] Pouff,int index,Image[] build,Image[] temporaire,Slider progressbar, bool[] placebuild,int changeindex)
    {
        StartCoroutine(AnimateImage(image, spriteCount, Pouff,index,build, temporaire,progressbar,placebuild,changeindex));
    }
    public bool[] Dejabuild;
    IEnumerator AnimateImage(Image image, int[] spriteCount, Sprite[] Pouff,int index,Image[] inbuild,Image[] temporaire,Slider progressbar, bool[] placebuild,int changeindex)
    {
        progressbar.gameObject.SetActive(false);
        Color pouf= image.color;
        pouf.a = 1f;
        image.color = pouf;
        int currentSpriteIndex = 0;
        while (currentSpriteIndex < Pouff.Length)
        {
            image.sprite = Pouff[currentSpriteIndex];
            currentSpriteIndex++;
            if(currentSpriteIndex==6)
            {
                for (int i = 0; i < index; i++)
                {
                    if (!Dejabuild[i] && changeindex != 10)
                    {
                        FadeImages(inbuild[i], temporaire[i]);
                        Dejabuild[i] = true;
                        placebuild[i] = true;
                    }
                    //spécifique swo
                   if (!Dejabuild[i] && changeindex == 10)// && !placebuild[i])
                    {
                        FadeImages(inbuild[i], temporaire[i]);
                        Dejabuild[i] = true;
                        placebuild[i] = true;
                    }
                }
               /* for (int i = 0; i < index; i++)
                {
                    if(!Dejabuild[i] && changeindex != 10)
                    {
                        FadeImages(inbuild[i], temporaire[i]);//changeindex-y-1
                        y--;
                        Dejabuild[i] = true;
                        placebuild[i] = true;
                    }
                    y++;
                }*/

            }
            yield return new WaitForSeconds(0.05f);
        }
        ResetSpriteCount(spriteCount);
        pouf.a = 0f;
        image.color = pouf;
        image.gameObject.SetActive(false);
        placebuild[index] = true;//-1


    }
    void ResetSpriteCount(int[] spriteCount)
    {
        for (int i = 0; i < spriteCount.Length; i++)
        {
            spriteCount[i] = 0;
        }
    }
    void FadeImages(Image imagesToFadeOut, Image imagesToFadeIn)
    {
        Color colorToFadeOut = imagesToFadeOut.color;
        colorToFadeOut.a = 0f;
        //builded.alpha = 1f;
        Color colorToFadeIn = imagesToFadeIn.color;
        colorToFadeIn.a = 1f;

        imagesToFadeOut.color = colorToFadeOut;
        imagesToFadeIn.color = colorToFadeIn;
    }
}


