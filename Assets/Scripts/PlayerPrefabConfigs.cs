using UnityEngine;

public class PlayerPrefabConfigs : MonoBehaviour
{
    const string SCORE_KEY = "score";

    const string SCORE1_KEY = "score1";

    const string SCORE2_KEY = "score2";

    const string SCORE3_KEY = "score3";

    const string SCORE5_KEY = "score5";

    const string High1_Key = "high1";

    const string High2_Key = "high2";

    const string High3_Key = "high3";

    const string High4_Key = "high4";

    const string High5_Key = "high5";

    const string INIT_KEY = "init";

    const string diem_KEY = "diem";

    const string FirstTime_Key = "firtTime";

    public static int SetDiem
    {
        get { return PlayerPrefs.GetInt(diem_KEY); }
        set { PlayerPrefs.SetInt(diem_KEY, value); }
    }
    public static int GetDiem()
    {
        return PlayerPrefs.GetInt(diem_KEY);
    }
    public static int SetInit
    {
        get { return PlayerPrefs.GetInt(INIT_KEY); }
        set { PlayerPrefs.SetInt(INIT_KEY, value); }
    }

    public static int GetInit()
    {
        return PlayerPrefs.GetInt(INIT_KEY);
    }

    public static int SetScore5
    {
        get { return PlayerPrefs.GetInt(SCORE5_KEY); }
        set { PlayerPrefs.SetInt(SCORE5_KEY, value); }
    }

    public static int GetScore5()
    {
        return PlayerPrefs.GetInt(SCORE5_KEY);
    }

    public static int SetScore1
    {
        get { return PlayerPrefs.GetInt(SCORE1_KEY); }
        set { PlayerPrefs.SetInt(SCORE1_KEY, value); }
    }

    public static int GetScore1()
    {
        return PlayerPrefs.GetInt(SCORE1_KEY);
    }

    public static int SetScore2
    {
        get { return PlayerPrefs.GetInt(SCORE2_KEY); }
        set { PlayerPrefs.SetInt(SCORE2_KEY, value); }
    }

    public static int GetScore2()
    {
        return PlayerPrefs.GetInt(SCORE2_KEY);
    }

    public static int SetScore3
    {
        get { return PlayerPrefs.GetInt(SCORE3_KEY); }
        set { PlayerPrefs.SetInt(SCORE3_KEY, value); }
    }

    public static int GetScore3()
    {
        return PlayerPrefs.GetInt(SCORE3_KEY);
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
