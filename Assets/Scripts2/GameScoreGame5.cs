using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScoreGame5 : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score;

    void Update()
    {
        score.text = PlayerPrefs.GetInt("score5").ToString();
        if (PlayerPrefs.GetInt("score5") > PlayerPrefs.GetInt("high5"))
            PlayerPrefs.SetInt("high5", PlayerPrefs.GetInt("score5"));
    }


}
