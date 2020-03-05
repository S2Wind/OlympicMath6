using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    [SerializeField] AudioClip wrongChoice;
    [SerializeField] AudioClip trueChoice;
    [SerializeField] AudioClip unsureChoice;
    [SerializeField] AudioClip otherChoice;
    [SerializeField] AudioClip backtrack;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //public void PlayWrongChoice()
    //{

    //}
}
