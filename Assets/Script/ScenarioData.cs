using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "ScenarioData", menuName = "Deca Game/Scenario Data")]

public class ScenarioData : ScriptableObject
{
    public int id;
    public string round;
    public string money;
    public string scenarioDetail;
}
