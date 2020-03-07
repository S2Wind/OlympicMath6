using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControler : MonoBehaviour
{
    [SerializeField] AudioClip wrongChoice;
    [SerializeField] AudioClip trueChoice;
    [SerializeField] AudioClip unsureChoice;
    [SerializeField] AudioClip otherChoice;
    [SerializeField] AudioClip backtrack;
    AudioSource audioSource;

    [SerializeField] Slider musicVolume;
    [SerializeField] Slider gameMusicVolume;

    public void FindSlider()
    {
            musicVolume = GameObject.Find("Music").GetComponent<Slider>();
            gameMusicVolume = GameObject.Find("GameMusic").GetComponent<Slider>();
    }

    private void Awake()
    {
        if(FindObjectsOfType<MusicControler>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        musicVolume.value = MusicConfig.GetMusicKey();
        gameMusicVolume.value = MusicConfig.GetGameMusicKey();
        if (PlayerPrefs.HasKey("Music_Key"))
        {
            MusicConfig.SetMusicKey(0.6f);
        }
        if (PlayerPrefs.HasKey("GameMusic_Key"))
        {
            MusicConfig.SetGameMusicKey(0.6f);
        }
    }

    private void Start()
    {
        audioSource.volume = MusicConfig.GetMusicKey();
    }



    private void Update()
    {
        if (GameObject.Find("GameMusic").GetComponent<Slider>() != null)
        {
            MusicConfig.SetMusicKey(musicVolume.value);
            MusicConfig.SetGameMusicKey(gameMusicVolume.value);
            Debug.Log(MusicConfig.GetGameMusicKey());
            audioSource.volume = MusicConfig.GetMusicKey();
        }
    }

    public void PlayWrong()
    {
        audioSource.PlayOneShot(wrongChoice, MusicConfig.GetGameMusicKey());
    }

    public void PlayTrue()
    {
        audioSource.PlayOneShot(trueChoice, MusicConfig.GetGameMusicKey());
    }

    public void PlayUnsure()
    {
        audioSource.PlayOneShot(unsureChoice, MusicConfig.GetGameMusicKey());
    }

    public void PlayOther()
    {
        audioSource.PlayOneShot(otherChoice, MusicConfig.GetGameMusicKey());
    }

    public void PlayBackTrack(AudioClip clip)
    {
        audioSource.Play();
    }
}
