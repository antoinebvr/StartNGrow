using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class Infobulle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Gps;
    public Color color1;
    public Color color2;
    public GameObject infobulle;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Gps.color = color1;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Gps.color = color2;
    }

}
