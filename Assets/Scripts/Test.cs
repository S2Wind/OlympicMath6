using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("firstTime",1) == 1)
        {
            PlayerPrefabConfigs.SetScore = 0;
            PlayerPrefabConfigs.SetScore1 = 0;
            PlayerPrefabConfigs.SetScore2 = 0;
            PlayerPrefabConfigs.SetScore3 = 0;
            PlayerPrefabConfigs.SetScore5 = 0;
            PlayerPrefs.SetInt("firstTime", 0);
        }
    }

}
