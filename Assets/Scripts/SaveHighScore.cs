using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveHighScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] textGUI;

    void Awake()
    {
        textGUI[0].text = "Điểm cao\n" + PlayerPrefs.GetInt("high1").ToString();
        textGUI[1].text = "Điểm cao\n" + PlayerPrefs.GetInt("high2").ToString();
        textGUI[2].text = "Điểm cao\n" + PlayerPrefs.GetInt("high3").ToString();
        textGUI[3].text = "Điểm cao\n" + PlayerPrefabConfigs.GetScore().ToString();
        textGUI[4].text = "Điểm cao\n" + PlayerPrefs.GetInt("high5").ToString();
    }

}
