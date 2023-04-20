using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public void Start()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }    
}