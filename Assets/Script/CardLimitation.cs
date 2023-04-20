using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;
using TMPro;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class CardLimitation : MonoBehaviour
{
    //public GameObject gris;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CardMenu menu;
    public void ActivationLimit(int i,GameObject gris)
    {
       //gris =FindObjectOfType<GameObject>(name=="gris");

        gris.SetActive(true);
        gris.gameObject.SetActive(true);
        menu.Grise[i].SetActive(true);
        Button bouton = GetComponentInParent<Button>();
        GameObject parent = menu.Grise[i].transform.parent.gameObject;
        Button bouton2 = parent.GetComponent<Button>();
        if (bouton2 != null)
        {
            bouton2.enabled = false;

            // Désactiver l'animation de la carte dans le parent
            CardAnimation codeBouton2 = parent.GetComponent<CardAnimation>();
            if (codeBouton2 != null)
            {
                codeBouton2.enabled = false;
            }
        }
        if (bouton != null)
            {
                bouton.GetComponent<Button>().enabled = false;
                //bouton.interactable = false;
                
                CardAnimation codeBouton = bouton.GetComponent<CardAnimation>();
                if (codeBouton != null)
                {
                    codeBouton.enabled = false;
                }
            }
    }
    public void DeactivationLimit(int i,GameObject gris)
    {

        //gris.SetActive(false);
        menu.Grise[i].SetActive(false);
       // Button bouton = GetComponentInParent<Button>();
        GameObject parent = menu.Grise[i].transform.parent.gameObject;
        Button bouton2 = parent.GetComponent<Button>();
        if (bouton2 != null)
        {
            bouton2.enabled = true;

            // Désactiver l'animation de la carte dans le parent
            CardAnimation codeBouton2 = parent.GetComponent<CardAnimation>();
            if (codeBouton2 != null)
            {
                codeBouton2.enabled = true;
            }
        }
       /* if (bouton != null)
        {
            bouton.enabled = true;
            CardAnimation codeBouton = bouton.GetComponent<CardAnimation>();
            if (codeBouton != null)
            {
                codeBouton.enabled = true;
            }
        }*/
    }
}
