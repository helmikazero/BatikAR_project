using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitProgram ()
    {
        Application.Quit();
    }
}