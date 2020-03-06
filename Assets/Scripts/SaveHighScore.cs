using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveHighScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] textGUI;

    void Awake()
    {
        textGUI[0].text = PlayerPrefs.GetInt("high1").ToString();
        textGUI[1].text = PlayerPrefs.GetInt("high2").ToString();
        textGUI[2].text = PlayerPrefs.GetInt("high3").ToString();
        textGUI[3].text = PlayerPrefabConfigs.GetScore().ToString();
        textGUI[4].text = PlayerPrefs.GetInt("high5").ToString();
    }

}
