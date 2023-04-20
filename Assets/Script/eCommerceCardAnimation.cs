using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class eCommerceCardAnimation : MonoBehaviour
{
    public RectTransform fromStoreRectTransform;
    public RectTransform fromWarehouseRectTransform;
    public float time = 1f;

    private void Start() 
    {
        fromStoreRectTransform.transform.localPosition = new Vector3(400f, -1000f, 0);
        fromWarehouseRectTransform.transform.localPosition = new Vector3(400f, -1000f, 0);
    }

    public void FromStoreMoveIn()
    {
        fromStoreRectTransform.transform.localPosition = new Vector3(400f,-1000f,0f);
        fromStoreRectTransform.DOAnchorPos(new Vector2(400f, -200f), time, false);
        StartCoroutine("WaitBeforeSplit");
        // fromStoreRectTransform.DOAnchorPos(new Vector2(525f,-200f), time, false);
        Debug.Log("Partie1");
    }

    public void FromWarehouseMoveIn()
    {
        fromWarehouseRectTransform.transform.localPosition = new Vector3(400f, -1000f, 0f);
        fromWarehouseRectTransform.DOAnchorPos(new Vector2(400f, -200f), time, false);
        StartCoroutine("WaitBeforeSplit");
        // fromWarehouseRectTransform.DOAnchorPos(new Vector2(275f, -200f), time, false);
        Debug.Log("Partie2");
    }

    IEnumerator WaitBeforeSplit()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(0.25f);
    }
}
