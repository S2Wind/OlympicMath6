using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject back;

    private void Awake()
    {
        FindObjectOfType<MusicControler>().FindSlider();
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
