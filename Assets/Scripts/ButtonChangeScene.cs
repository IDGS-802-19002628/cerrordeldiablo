using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour
{
    public string scene;

    public void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }
}
