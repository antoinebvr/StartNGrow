using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ToggleCountryName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public GameObject infobulleCountryName;

    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        infobulleCountryName.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData) 
    {
        infobulleCountryName.SetActive(false);
        
    }

}
