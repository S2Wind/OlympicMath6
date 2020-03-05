using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenu : MonoBehaviour
{
    public void LoadSceneGame1()
    {
        SceneManager.LoadScene("startgame1");
    }

    public void LoadSceneGame2()
    {
        SceneManager.LoadScene("startgame2");
    }

    public void LoadSceneGame3()
    {
        SceneManager.LoadScene("startgame3");
    }

    public void LoadSceneGame4()
    {
        SceneManager.LoadScene("Game4");
    }

    public void LoadSceneGame5()
    {
        SceneManager.LoadScene("Game5");
    }
}
