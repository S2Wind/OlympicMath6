using UnityEngine;

public class PlayerPrefabConfigs : MonoBehaviour
{
    const string SCORE_KEY = "score";
    
    public static int SetScore
    {
        get { return PlayerPrefs.GetInt(SCORE_KEY); }
        set { PlayerPrefs.SetInt(SCORE_KEY, value); }
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }
}
