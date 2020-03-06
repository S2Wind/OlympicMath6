using UnityEngine;

public class PlayerPrefabConfigs : MonoBehaviour
{
    const string SCORE_KEY = "score";

    const string INIT_KEY = "init";

    public static int SetInit
    {
        get { return PlayerPrefs.GetInt(INIT_KEY); }
        set { PlayerPrefs.SetInt(INIT_KEY, value); }
    }

    public static int GetInit()
    {
        return PlayerPrefs.GetInt(INIT_KEY);
    }
    
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
