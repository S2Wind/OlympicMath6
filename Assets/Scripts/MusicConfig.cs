using UnityEngine;

public class MusicConfig : MonoBehaviour
{
    const string GAMEMUSIC_KEY = "GameMusic_Key";
    const string MUSIC_KEY = "Music_Key";

    

    public static void SetGameMusicKey(float vol)
    {
        if(vol >= 0 && vol <=1)
        {
            PlayerPrefs.SetFloat(GAMEMUSIC_KEY, vol);
        }
        else
        {
            Debug.LogError("Game Music is out of range");
        }
    }

    public static float GetGameMusicKey()
    {
        return PlayerPrefs.GetFloat(GAMEMUSIC_KEY);
    }

    public static void SetMusicKey(float vol)
    {
        if (vol >= 0 && vol <= 1)
        {
            PlayerPrefs.SetFloat(MUSIC_KEY, vol);
        }
        else
        {
            Debug.LogError("Game Music is out of range");
        }
    }

    public static float GetMusicKey()
    {
        return PlayerPrefs.GetFloat(MUSIC_KEY);
    }

}
