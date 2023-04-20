using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreyMouseOver : MonoBehaviour
{
    public GameObject gris;
    public bool isGris = false;

    public void Update() 
    {
        if(gris.activeSelf == true)
        {
            isGris = true;
        }
        else if(gris.activeSelf == false)
        {
            isGris = false;
        }
    }
}
