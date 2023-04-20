using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float speed = 0.25f;
    public bool mouseIsOver = false;
    public RectTransform[] otherCards;
    public bool isActive = false;
    public GreyMouseOver isGrey;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseIsOver = true;
        if(isGrey.isGris == false)
        {
            OnHighlight();
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        mouseIsOver = false;
        ExitHighlight();
    }

    public void OnHighlight()
    {
        transform.DOScale(1.1f, speed).SetEase(Ease.Flash);
    }

    public void ExitHighlight()
    {
        transform.DOScale(1f, speed).SetEase(Ease.Flash);
    }

    public void focusCard()
    {
        transform.DOMoveY(350, 0.25f, false);
    }
    public void focusCard(GameObject GetSelected)
    {
        GetSelected.transform.DOMoveY(350, 0.5f, false);
    }
    public void stopFocusCard()
    {
        for(int i = 0; i < otherCards.Length; i++)
        {
            RectTransform othercard = otherCards[i];
            otherCards[i].transform.DOMoveY(297, 0.25f, false);
        }
    }
} 
