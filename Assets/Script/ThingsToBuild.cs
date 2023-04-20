using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThingsToBuild : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite constructionSkin;
    public Sprite normalSkin;
    public Sprite transparencySkin;

    public float animationSpeed = 1;
    public bool builded = false;
    public int roundBeforeBuild = 5;

    
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = constructionSkin;
        Spawn();
        Upgrade();
    }

    public void Spawn()
    {
        transform.DOLocalMoveY(0, animationSpeed, false).SetEase(Ease.OutBounce);
    }

    public void Upgrade()
    {
        if(roundBeforeBuild >= 0)
        {
            gameObject.GetComponent<Image>().sprite = normalSkin;
            builded = true;
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(builded)
        {
            //On affiche le flux lié
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if(builded)
        {
            
        }
    }




}
