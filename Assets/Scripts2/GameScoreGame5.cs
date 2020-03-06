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
    }


}
