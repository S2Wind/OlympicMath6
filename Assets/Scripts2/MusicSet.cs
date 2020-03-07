using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSet : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    void Start()
    {
        FindObjectOfType<MusicControler>().GetComponent<AudioSource>().clip = clip;
        FindObjectOfType<MusicControler>().GetComponent<AudioSource>().Play();
    }

}
