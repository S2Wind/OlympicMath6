using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSet : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    void Start()
    {
        if (FindObjectOfType<MusicControler>().canChangeScene)
        {
            FindObjectOfType<MusicControler>().GetComponent<AudioSource>().clip = clip;
            FindObjectOfType<MusicControler>().GetComponent<AudioSource>().Play();
            FindObjectOfType<MusicControler>().canChangeScene = false;
        }
    }

}
