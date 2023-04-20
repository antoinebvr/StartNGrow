using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ConstructionPlace : MonoBehaviour
{
    // tableaux d'emplacements pour construire : 1 pour les cac car, 1 pour les types de stores, 1 pour ce qui est lié à l'e-com
    public RectTransform[] cacCarPlacesToBuilds;
    public RectTransform[] storePlacesToBuilds;
    public RectTransform[] ecomPlacesToBuilds;


    // donne la position dans le tableau des emplacements
    public int indexCacCarPlaceAvailable = 0;
    public int indexStorePlaceAvailable = 0;
    public int indexEcomPlaceAvailable = 0;
    public int indexCamionPlaceWaiting = 1;

    // tableaux de boolean qui vérifie si les emplacements de constructions sont utilisés ou non
    public bool[] cacCarPlaceIsAvailables;
    public bool[] storePlaceIsAvailables;
    public bool[] ecomPlaceIsAvailables;
    public bool[] CamionIsAvailables;
    //public bool[] placebuildPopUp;
    //public bool[] placebuildStore;
    //public bool[] placebuildSwo;
    //public bool[] placebuildCacCar540;
   // public bool[] placebuildCacCarFull;
    public bool[] placebuild;
    // donne la position dans le tableau des gameobjects batiments
    public int indexCacCar = 0;
    public int indexStore = 0;
    public int indexPopup = 0;
    public int indexEcom = 0;
    public int indexCamion = 1;
    // tableaux de batîments  
    public Image[] cacCars;
    public Image[] stores;
    public Image[] popups;
    public Image[] ecoms;
    public Image[] Camion;
    public Image[] TemporairesStores; //store dont on va diminué l'alpha pour le rentre transparent
    public Image[] TemporairesPopUp;
    public Image[] TemporairesSwo;


    // autres sprites (uniques)
    public Image marketPlace;
    public Image swoPartner;
    public Image city;
    public Image CacCaR540;
    public Image CacCarFullOffer;

    // tableaux d'@ à activer quand les cartes jouées
    public GameObject[] fromStores;
    public GameObject[] fromWarehouses;
    //Prends le parent des images camions
    public GameObject ParentCamion;

    // références
    public CashFlow cashFlow;
   // public Progress_Bar bar;
    // attributs
    public float animationSpeed = 1;
    //variable pour progress bar

    public Vector3 marketPlaceStartPosition;
    public int y = 0;
    void Start()
    {
        setConstructionPosition();
        setBools();
        foreach (Image image in Camion)
        {
            image.gameObject.SetActive(false);
        }
    }
    public void verifyPlaceAvailable()
    {
        // vérifie si un emplacement est utilisé, s'il est utilisé, on sélectionne l'emplacement suivant dans le tableau
        for (int i = 0; i < cacCarPlaceIsAvailables.Length; i++)// utilisé pour les 2 sortes (id 5et 6)cac/car ????
        {
            if (cacCarPlaceIsAvailables[i] && (cashFlow.verifid == 5 || cashFlow.verifid == 6))
            {
                for (int j = 0; j < cacCars.Length; j++)
                {
                    cacCars[indexCacCar].rectTransform.DOMoveX(cacCarPlacesToBuilds[indexCacCarPlaceAvailable].transform.position.x, 0.1f, false);
                }
            }
        }

        for (int i = 0; i < storePlaceIsAvailables.Length; i++)
        {
            if (storePlaceIsAvailables[i] && cashFlow.verifid == 1 || cashFlow.verifid == 15)
            {
                for (int j = 0; j < (stores.Length); j++)
                {
                    stores[indexStore].rectTransform.DOMoveX(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.x, 0.1f, false);
                }
            }
        }

        for (int i = 0; i < storePlaceIsAvailables.Length; i++)
        {
            if (storePlaceIsAvailables[i] && cashFlow.verifid == 2)
            {
                for (int j = 0; j < popups.Length; j++)
                {
                    popups[indexPopup].rectTransform.DOMoveX(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.x, 0.1f, false);// remplace i par indexpopup
                }
            }
        }

        for (int i = 0; i < ecomPlaceIsAvailables.Length; i++)
        {
            if (ecomPlaceIsAvailables[i])
            {
                for (int j = 0; j < ecoms.Length; j++)
                {
                    ecoms[indexEcom].rectTransform.DOMoveX(ecomPlacesToBuilds[indexEcomPlaceAvailable].transform.position.x, 0.1f, false);
                }
            }
        }

    }

    public void PlayACard()
    {
        switch (cashFlow.verifid)
        {
            case 0:
                // afficher l'écran de confirmation de passer le tour
                break;
            case 1:
                BuildStore();
                break;
            case 2:
                BuildPopUp();
                break;
            case 3:
                BuildMarketPlace();
                break;
            case 4:
                BuildSwoPartner();
                break;
            case 5:
                BuildCacCar540();
                break;
            case 6:
                BuildCacCarFullOffer();
                break;
            case 7:
                CamionWaitingParking();
                break;
            case 8:
                CamionWaitingParking();
                break;
            case 9:
                CamionWaitingParking();
                break;
            case 10:
                CamionWaiting();
                break;
            case 11:
                CamionWaitingParking();
                break;
            case 12:
                CamionWaitingParking();
                break;
            case 13:
                BuildFromStore();
                break;
            case 14:
                BuildFromWareHouse();
                break;
            case 15:
                BuildStore();
                BuildStore();
                break;
        }
    }

    public void BuildStore()
    {
        verifyPlaceAvailable();
        stores[indexStore].GetComponent<RectTransform>().DOMoveY(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.y, animationSpeed, false).SetEase(Ease.OutBounce);
        storePlaceIsAvailables[indexStorePlaceAvailable] = false;
        indexStorePlaceAvailable++;
        if (indexStore < stores.Length)
            indexStore++;
    }
    public void BuildPopUp()
    {
        verifyPlaceAvailable();
        popups[indexPopup].GetComponent<RectTransform>().DOMoveY(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.y, animationSpeed, false).SetEase(Ease.OutBounce);
        storePlaceIsAvailables[indexStorePlaceAvailable] = false;
        indexStorePlaceAvailable++;
        if (indexPopup < popups.Length)
            indexPopup++;
    }
    public void BuildSwoPartner()
    {
        swoPartner.GetComponent<RectTransform>().DOMoveX(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.x, 0.1f, false);
        swoPartner.GetComponent<RectTransform>().DOMoveY(storePlacesToBuilds[indexStorePlaceAvailable].transform.position.y, animationSpeed, false).SetEase(Ease.OutBounce);
        storePlaceIsAvailables[indexStorePlaceAvailable] = false;
        indexStorePlaceAvailable++;
        indexswo++;
    }
    public void BuildMarketPlace()
    {
        marketPlace.GetComponent<RectTransform>().DOLocalMove(marketPlaceStartPosition, animationSpeed, false).SetEase(Ease.OutBounce);
        marketPlace.color = new Color(255, 255, 255, 255);
    }
    public void BuildCacCar540()
    {
        verifyPlaceAvailable();
        cacCars[0].GetComponent<RectTransform>().DOMoveY(cacCarPlacesToBuilds[indexCacCarPlaceAvailable].transform.position.y, animationSpeed, false).SetEase(Ease.OutBounce);
        cacCarPlaceIsAvailables[indexCacCarPlaceAvailable] = false;
        indexCacCarPlaceAvailable++;

    }
    public void BuildCacCarFullOffer()
    {
        verifyPlaceAvailable();
        cacCars[1].GetComponent<RectTransform>().DOMoveY(cacCarPlacesToBuilds[indexCacCarPlaceAvailable].transform.position.y, animationSpeed, false).SetEase(Ease.OutBounce);
        cacCarPlaceIsAvailables[indexCacCarPlaceAvailable] = false;
        indexCacCarPlaceAvailable++;
    }

    public void CamionWaiting()
    {
        foreach (Transform child in ParentCamion.transform)
        {
            Image image = child.GetComponent<Image>();
            if (image.name == "Camion entrepot")
            {
                image.gameObject.SetActive(true);
            }
        }
        CamionIsAvailables[0] = false;
    }
    public void CamionWaitingParking()
    {
        for (int i = 1; i < CamionIsAvailables.Length; i++)
        {
            if (CamionIsAvailables[i])
            {

                foreach (Transform child in ParentCamion.transform)
                {
                    Image image = child.GetComponent<Image>();
                    if (image.name == "Camion Parking " + indexCamion.ToString())
                    {
                        image.gameObject.SetActive(true);
                        CamionIsAvailables[i] = false;
                    }
                }
                CamionIsAvailables[indexCamionPlaceWaiting] = false;
                indexCamionPlaceWaiting++;

            }
        }

    }
    public void BuildFromStore()
    {
        for (int i = 0; i < fromStores.Length; i++)
        {
            fromStores[i].SetActive(true);
        }
    }
    public void BuildFromWareHouse()
    {
        for (int i = 0; i < fromWarehouses.Length; i++)
        {
            fromWarehouses[i].SetActive(true);
        }
    }
    public void setConstructionPosition()
    {
        // Place les constructions en dehors de l'écran, au dessus
        for (int i = 0; i < cacCars.Length; i++)
        {
            Image cacCar = cacCars[i];
            cacCars[i].transform.localPosition = new Vector2(0, 800);
        }
        for (int i = 0; i < stores.Length; i++)
        {
            Image store = stores[i];
            stores[i].transform.localPosition = new Vector2(0, 800);
        }
        for (int i = 0; i < popups.Length; i++)
        {
            Image popup = popups[i];
            popups[i].transform.localPosition = new Vector2(0, 800);
        }
        for (int i = 0; i < cacCars.Length; i++)
        {
            Image ecom = ecoms[i];
            ecoms[i].transform.localPosition = new Vector2(0, 800);
        }
        swoPartner.transform.localPosition = new Vector2(0, 800);
        marketPlace.transform.localPosition = new Vector2(500, 800);
    }
    public void setBools()
    {
        // Vérifie que les emplacements pour construire sont disponible
        for (int i = 0; i < cacCarPlaceIsAvailables.Length; i++)
        {
            bool cacCarPlaceIsAvailable = cacCarPlaceIsAvailables[i];
            cacCarPlaceIsAvailables[i] = true;
        }
        for (int i = 0; i < storePlaceIsAvailables.Length; i++)
        {
            bool storePlaceIsAvailable = storePlaceIsAvailables[i];
            storePlaceIsAvailables[i] = true;
        }
        for (int i = 0; i < ecomPlaceIsAvailables.Length; i++)
        {
            bool ecomPlaceIsAvailable = ecomPlaceIsAvailables[i];
            ecomPlaceIsAvailables[i] = true;
        }
    }
    static float Alpha =0.75f;
    int indexall;
    int indexswo=0;
    public void ClickTransparent()
    {
        indexall = ((indexStore + indexPopup)+indexswo);

        switch (cashFlow.verifid)
        {
            case 0:
                ClickBack(); // désactive tout l'élement transparent actif
                break;
            case 1:
                ClickBack();
                Color ImageColor = TemporairesStores[indexall].color;
                ImageColor.a = Alpha;
                TemporairesStores[indexall].color = ImageColor; //juste faire apparaitre le store en transparent*/
                                                                  //  x = 1;
                break;
            case 2:
                ClickBack();
                Color ImageColor2 = TemporairesPopUp[indexall].color;
                ImageColor2.a = Alpha;
                TemporairesPopUp[indexall].color = ImageColor2;
                break;
            case 3:
                ClickBack();
                Color ImageColor3 = marketPlace.color;
                ImageColor3.a = Alpha;
                marketPlace.color = ImageColor3;
                break;
            case 4:
                ClickBack();
                Color ImageColor4 = TemporairesSwo[indexall].color;
                ImageColor4.a = Alpha;
                TemporairesSwo[indexall].color = ImageColor4;
                break;
            case 5:
                ClickBack();
                Color ImageColor5 = CacCaR540.color;
                ImageColor5.a = Alpha;
                CacCaR540.color = ImageColor5;
                break;
            case 6:
                ClickBack();
                Color ImageColor6 = CacCarFullOffer.color;
                ImageColor6.a = Alpha;
                CacCarFullOffer.color = ImageColor6;
                break;
            case 7:
                ClickBack();
                break;
            case 8:
                ClickBack();
                break;
            case 9:
                ClickBack();
                break;
            case 10:
                ClickBack();
                break;
            case 11:
                ClickBack();
                break;
            case 12:
                ClickBack();
                break;
            case 13:
                ClickBack();
                break;
            case 14:
                ClickBack();
                break;
            case 15:
                ClickBack();
                Color ImageColor15 = TemporairesStores[indexall].color;
                ImageColor15.a = Alpha;
                TemporairesStores[indexall].color = ImageColor15;
                TemporairesStores[indexall + 1].color = ImageColor15;
                break;
        }
    }
    public float endAlpha = 0f;
    public float duration = 0.05f;
    public Ease ease = Ease.OutCirc;

    public void ClickBack()
    {
        for (int i = 1; i < 16; i++)
        {
            switch (i)
            {
                case 1:
                    for (int j = 0; j < indexall + 1; j++)
                    {
                        Color ImageColor = TemporairesStores[indexall].color;
                        ImageColor.a = endAlpha;
                        TemporairesStores[indexall].color = ImageColor;
                    }
                    break;
                case 2:
                    for(int j=0; j < indexall+1;  j++)
                    {
                        if (placebuild[j] == false )//&& !bar.Dejabuild[j] )
                        {
                            Color ImageColor2 = TemporairesPopUp[j].color;
                            ImageColor2.a = endAlpha;
                            TemporairesPopUp[j].color = ImageColor2;
                        }

                        
                    }
                    break;
                case 3:
                        Color ImageColor3 = marketPlace.color;
                         ImageColor3.a = endAlpha;
                         marketPlace.color = ImageColor3;
                    break;
                case 4:
                    for(int j = 0;j < indexall + 1; j++)
                    {
                        if (placebuild[j] == false)
                        {
                            Color ImageColor4 = TemporairesSwo[j].color;
                        ImageColor4.a = endAlpha;
                        TemporairesSwo[j].color = ImageColor4;
                        }
                    }
                    break;
                case 5:
                    Color ImageColor5 = CacCaR540.color;
                    ImageColor5.a = endAlpha;
                    CacCaR540.color = ImageColor5;
                    break;
                case 6:
                    Color ImageColor6 = CacCarFullOffer.color;
                    ImageColor6.a = endAlpha;
                    CacCarFullOffer.color = ImageColor6;
                    break;
                case 15:
                    if (TemporairesStores[indexall].color.a !=0 && TemporairesStores[indexall + 1].color.a != 0)
                    {
                        Color ImageColor15 = TemporairesStores[indexall].color;
                        ImageColor15.a = endAlpha;
                        TemporairesStores[indexall].color = ImageColor15;
                        TemporairesStores[indexall + 1].color = ImageColor15;
                    }
                    break;
            }
        }
    }

}
