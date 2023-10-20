using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_buttons : MonoBehaviour
{
    public void Play()
    {   
        SceneManager.LoadSceneAsync(1);
    }
    public void Settings()
    {

    }
    public void Destroy()
    {
        Application.Quit();
    }
}
