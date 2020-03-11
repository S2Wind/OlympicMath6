﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Clocks : MonoBehaviour
{
    [Range(0, 20)] [SerializeField] int m;

    [Range(0, 60)] [SerializeField] float s;

    [SerializeField] TextMeshProUGUI mText;
    [SerializeField] TextMeshProUGUI sText;

    [SerializeField] GameObject gameManager;

    public bool timeOver = false;

    bool timeRun = true;

    public void SetClock(int a, float b)
    {
        m = a; s = b;
    }

    void RunClock()
    {
        int tmp = (int)s;
        if (m >= 10)
        {
            mText.text = m.ToString();
        }
        else
        {
            mText.text = "0" + m.ToString();
        }
        if (tmp >= 10)
        {
            sText.text = tmp.ToString();
        }
        else
        {
            sText.text = "0" + tmp.ToString();
        }
    }
    void Update()
    {
        if (!timeOver && timeRun)
        {
            s -= Time.deltaTime;
            if (s <= 0)
            {
                m--;
                s = 60;
            }
            RunClock();
            TimeOver();
        }
        else
        {
            if (timeRun)
            {
                FindObjectOfType<GameManager3>().TimeOut();
                StartCoroutine(YouEarnPanel());
                timeRun = false;
            }
        }

        void TimeOver()
        {
            if (m <= 0 && s < 1)
            {
                timeOver = true;
            }
        }
    }

    IEnumerator YouEarnPanel()
    {
        FindObjectOfType<GameManager3>().ActivePanel();
        FindObjectOfType<GameManager3>().End1Round();
        FindObjectOfType<GameManager3>().SetScore();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("game5");
    }
}
