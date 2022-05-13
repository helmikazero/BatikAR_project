using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    
    //Mengatur Scene yang akan dibuka
    public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // Keluar dari aplikasi
    public void QuitProgram ()
    {
        Application.Quit();
    }
}