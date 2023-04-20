using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "ButtonData", menuName = "Deca Game/Button Data")]
public class ButtonData : ScriptableObject
{
    public int id;
    public string sceneName;
}
