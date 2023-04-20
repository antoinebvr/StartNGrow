using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConstructionAnimation : MonoBehaviour
// , IPointerEnterHandler, IPointerExitHandler
{
    public float animationSpeed = 1f;
    public float speed2 = 0.5f;
    public float rotationSpeed = 0.1f;
    public int vibration = 1;
    public float elasticity = 1f;
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;
    public GameObject raycaster;

    public Color initialColor;
    public Color secondColor;
    public GameObject infobulle;

    public Sprite final;

    private void Start() 
    {
        
        transform.localPosition = new Vector2(0, 700);
    }

    public void Spawn()
    {
        raycaster.SetActive(true);
        transform.DOLocalMoveY(0, animationSpeed, false).SetEase(Ease.OutBounce);    
    }

    public void Upgrade()
    {
        transform.DOLocalRotate(new Vector3(0,1080,0), rotationSpeed, RotateMode.FastBeyond360).OnComplete(() =>
        {
            gameObject.GetComponent<Image>().sprite = final;
        });
    }

    // public void OnPointerEnter(PointerEventData pointerEventData)
    // {
    //     infobulle.SetActive(true);
    //     transform.DOScale(1.1f, 0.25f).SetEase(Ease.Flash);
    // }

    // public void OnPointerExit(PointerEventData pointerEventData)
    // {
    //     infobulle.SetActive(false);
    //     transform.DOScale(1f, 0.25f).SetEase(Ease.Flash);
    // }
}
