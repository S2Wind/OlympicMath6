using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenu : MonoBehaviour
{


    public void LoadSceneGame1()
    {
        FindObjectOfType<MusicControler>().GetComponent<MusicControler>().NullSlider();
        SceneManager.LoadScene("startgame1");
    }

    public void LoadSceneGame2()
    {
        FindObjectOfType<MusicControler>().GetComponent<MusicControler>().NullSlider();
        SceneManager.LoadScene("startgame2");
    }

    public void LoadSceneGame3()
    {
        FindObjectOfType<MusicControler>().GetComponent<MusicControler>().NullSlider();
        SceneManager.LoadScene("startgame3");
    }

    public void LoadSceneGame4()
    {
        FindObjectOfType<MusicControler>().GetComponent<MusicControler>().NullSlider();
        SceneManager.LoadScene("Game4");
    }

    public void LoadSceneGame5()
    {
        FindObjectOfType<MusicControler>().GetComponent<MusicControler>().NullSlider();
        SceneManager.LoadScene("Game5");
    }
}
