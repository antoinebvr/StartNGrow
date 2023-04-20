using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class EachGreyInfobulle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform infobulle;
    public TextMeshProUGUI text;
    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        infobulle.GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
        text.color = new Vector4(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData pointerEventData) 
    {
        infobulle.GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
        text.color = new Vector4(255, 255, 255, 0);
    }
}
