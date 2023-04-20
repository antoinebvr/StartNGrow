using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SelectButton : MonoBehaviour
{
    public ButtonData buttonData;
    public StartScenario sceneToStart;

    public Button button;
    public Sprite normal;
    public Sprite highlighted;
    public RectTransform rectTransform;

    private void Awake() 
    {
        button = GetComponent<Button>();
        rectTransform.GetComponent<RectTransform>();
    }
    public void SelectScenario()
    {
        sceneToStart.sceneToStart = buttonData.sceneName;
        button.image.sprite = highlighted;
        rectTransform.sizeDelta = new Vector2 (150, 150);
    }

    public void DeselectScenario()
    {
        button.image.sprite = normal;
        rectTransform.sizeDelta = new Vector2 (110, 110);
    }
}
