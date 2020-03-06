using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject back;

    [SerializeField] Slider musicVolume;
    [SerializeField] Slider gameMusicVolume;


    private void Update()
    {
        MusicConfig.SetMusicKey(musicVolume.value);
        MusicConfig.SetGameMusicKey(gameMusicVolume.value);
    }
    public void UserSelectSetting()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        back.SetActive(true);
        musicVolume.value = MusicConfig.GetMusicKey();
        Debug.Log(MusicConfig.GetMusicKey());
        gameMusicVolume.value = MusicConfig.GetGameMusicKey();
        Debug.Log(MusicConfig.GetGameMusicKey());
        if (PlayerPrefs.HasKey("Music_Key"))
        {
            MusicConfig.SetMusicKey(0.6f);
        }
        if (PlayerPrefs.HasKey("GameMusic_Key"))
        {
            MusicConfig.SetGameMusicKey(0.6f);
        }
    }

    public void UserSelectBackMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        back.SetActive(false);
    }
}
