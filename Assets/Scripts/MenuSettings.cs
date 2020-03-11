using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject back;

    [SerializeField] Slider music;
    [SerializeField] Slider gameMusic;

    [SerializeField] AudioClip clip;

    public void SetMusic(float a)
    {
        music.value = a;
    }

    public void SetGameMusic(float a)
    {
        gameMusic.value = a;
    }


    private void Start()
    {
        FindObjectOfType<MusicControler>().canChangeScene = true;
        FindObjectOfType<MusicControler>().GetSlider(music, gameMusic);
        FindObjectOfType<MusicControler>().PlayBackTrack(clip);
    }

    public void UserSelectSetting()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        back.SetActive(true);
    }

    public void UserSelectBackMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        back.SetActive(false);
    }


}
