using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CamionPath : MonoBehaviour
{
    public RectTransform[] checkPoints;
    public Sprite[] camionAngle;
    public RectTransform camion;

    // public Sprite camionHautGauche;
    // public Sprite camionHautDroite;
    // public Sprite camionBasGauche;
    // public Sprite camionBasDroite;

    public int currentPosition = 0;
    public int lastCheckPoint = 4;
    public bool camionEnable = false;
    public RectTransform startPosition;
    public Sprite startSprite;

    public float verySlowSpeed = 2f;
    public float slowSpeed = 2f;
    public float defaultSpeed = 2f;
    public float fastSpeed = 2f;
    public float veryFastSpeed = 2f;


    void Start()
    {
        camion.transform.position = startPosition.transform.position;
        camion.gameObject.GetComponent<Image>().sprite = startSprite;
        camion.transform.DOScale(1, 1).SetEase(Ease.OutBounce);
    }


    public void Update()
    {

    }

    public void GoCamion()
    {
        camion.GetComponent<Image>().sprite = camionAngle[3];
        Debug.Log("0");
        camion.transform.DOMove(checkPoints[0].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
        {
            camion.GetComponent<Image>().sprite = camionAngle[2];
            Debug.Log("1");
            camion.transform.DOMove(checkPoints[1].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
            {
                camion.GetComponent<Image>().sprite = camionAngle[3];
                Debug.Log("2");
                camion.transform.DOMove(checkPoints[2].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                {
                    camion.GetComponent<Image>().sprite = camionAngle[0];
                    Debug.Log("3");
                    camion.transform.DOMove(checkPoints[3].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        camion.GetComponent<Image>().sprite = camionAngle[3];
                        Debug.Log("4");
                        camion.transform.DOMove(checkPoints[4].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            camion.GetComponent<Image>().sprite = camionAngle[2];
                            Debug.Log("5");
                            camion.transform.DOMove(checkPoints[5].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                camion.GetComponent<Image>().sprite = camionAngle[1];
                                Debug.Log("6");
                                camion.transform.DOMove(checkPoints[6].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                                {
                                    camion.GetComponent<Image>().sprite = camionAngle[0];
                                    Debug.Log("7");
                                    camion.transform.DOMove(checkPoints[7].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                                    {
                                        camion.GetComponent<Image>().sprite = camionAngle[1];
                                        Debug.Log("8");
                                        camion.transform.DOMove(checkPoints[8].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                                        {
                                            camion.GetComponent<Image>().sprite = camionAngle[0];
                                            Debug.Log("9");
                                            camion.transform.DOMove(checkPoints[9].transform.position, defaultSpeed, false).SetEase(Ease.Linear).OnComplete(() =>
                                            {
                                                {
                                                    GoCamion();
                                                };
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    }

    // public void CamionCircuit()
    // {
    //     // if (camionEnable)
    //     // {
    //         if (currentPosition < lastCheckPoint)
    //         {
    //             currentPosition++;
    //             camion.transform.DOMove(checkPoints[currentPosition].position, speed1, false).SetEase(Ease.InOutQuint);
    //         }
    //         else if (currentPosition == lastCheckPoint)
    //         {
    //             currentPosition = 0;
    //             camion.transform.DOMove(checkPoints[currentPosition].position, speed1, false).SetEase(Ease.InOutQuint);
    //         }
    //     // }
    // }

    // public void SwitchSprite()
    // {
    //     if (currentPosition == 0)
    //     {
    //         gameObject.GetComponent<Image>().sprite = camionAngle[0];
    //     }
    //     if (currentPosition == 1)
    //     {
    //         gameObject.GetComponent<Image>().sprite = camionAngle[1];
    //     }
    //     if (currentPosition == 2)
    //     {
    //         gameObject.GetComponent<Image>().sprite = camionAngle[2];
    //     }
    //     if (currentPosition == 3)
    //     {
    //         gameObject.GetComponent<Image>().sprite = camionAngle[3];
    //     }
    //     if (currentPosition == 4)
    //     {
    //         gameObject.GetComponent<Image>().sprite = camionAngle[1];
    //     }
    // }
}
