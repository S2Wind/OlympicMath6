using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager7 : MonoBehaviour
{
    [Header("Q/A")]
    [SerializeField] Questions[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] Text[] answer;

    static List<Questions> unanswerQuestions;

    Questions curQues;
    private void Awake()
    {
        FindObjectOfType<Clock4>().SetClock(20, 1);
        InitQuestion();
    }

    public void InitQuestion()
    {
        StartQuestion ques = FindObjectOfType<StartQuestion>();
        int j = 0;
        for (int i = 0; i < ques.questions.Length; i++)
        {
            if (ques.questions[i].Type == 1)
            {
                j++;
            }
        }
        questions = new Questions[j];
        for (int i = 0; i < ques.questions.Length; i++)
        {
            if (ques.questions[i].Type == 1)
            {
                questions[j - 1] = ques.questions[i];
                j--;
            }
        }
    }

    public void TimeOut()
    {
        SceneManager.LoadScene("endgame3");
    }

    public void CheckIfItTrueOrNot()
    {
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        if (a[0].ToString() == curQues.CorrectAnswer)
        {
            FindObjectOfType<EventButton3>()._AC();
            FindObjectOfType<MusicControler>().PlayTrue();
        }
        else
        {
            FindObjectOfType<EventButton3>()._Wr();
            FindObjectOfType<MusicControler>().PlayWrong();
        }
    }
    void Start()
    {
        if (unanswerQuestions == null || unanswerQuestions.Count == 0)
        {
            InitQuestion();
            unanswerQuestions = questions.ToList<Questions>();
        }
        SetRandomQuestionAnswer();
    }

    public void SetRandomQuestionAnswer()
    {
        int randomIndex = Random.Range(0, unanswerQuestions.Count);
        curQues = unanswerQuestions[randomIndex];
        ques.text = curQues.Text;
        answer[0].text = curQues.A;
        answer[1].text = curQues.B;
        answer[2].text = curQues.C;
        answer[3].text = curQues.D;
    }
}
