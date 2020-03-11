using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestion : MonoBehaviour
{
    public Questions[] questions;
    void Start()
    {
        if(FindObjectsOfType<StartQuestion>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
