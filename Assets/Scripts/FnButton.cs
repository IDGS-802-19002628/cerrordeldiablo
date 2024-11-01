using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FnButton : MonoBehaviour
{
    public string scene;
    public void ButtonChange()
    {
        SceneManager.LoadScene(scene);
    }
    
}
