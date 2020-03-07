using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] GameObject e;

    public void MakeSure()
    {
        e.SetActive(true);
    }

    public void Cancel()
    {
        e.SetActive(false);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
