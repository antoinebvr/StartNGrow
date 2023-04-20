using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenario : MonoBehaviour
{
    public string sceneToStart;

    public void LaunchThisScenario()
    {
        SceneManager.LoadScene(sceneToStart);
    }
}
