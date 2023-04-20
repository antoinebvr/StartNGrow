using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseIsOver = false;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseIsOver = true;
        Debug.Log("MouseEnter");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        mouseIsOver = false;
        Debug.Log("MouseExit");
    }

    public void OnClick()
    {
        Debug.Log("JeClique");
    }

}
