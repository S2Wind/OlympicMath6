using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{

    [Header("Q/A")]
    [SerializeField] Questions[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] Text[] answer;

    static List<Questions> unanswerQuestions;

    Questions curQues;

    [SerializeField] float timeBetweenTrans = 2f;

    public int turn = 0;
    public Text txtTurn;

    public int point = 0;
    public Text txtPoint;

    public GameObject pnlQuestion;

    private void Awake()
    {
        FindObjectOfType<Clock3>().SetClock(20, 1);
        InitQuestion();
    }

    public void InitQuestion()
    {
        StartQuestion ques = FindObjectOfType<StartQuestion>();
        int j = 0;
        Debug.Log(ques.questions.Length);
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
        SceneManager.LoadScene("endgame2");
    }

    public void CheckIfItTrueOrNot()
    {
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        Debug.Log(a);
        if (a[0].ToString() == curQues.CorrectAnswer)
        {
            FindObjectOfType<EventButton2>()._btnAC();
            FindObjectOfType<MusicControler>().PlayTrue();
            if (PlayerPrefs.GetInt("high2") < point)
                PlayerPrefs.SetInt("high2",point);
        }
        else
        {
            FindObjectOfType<EventButton2>()._Wrong();
            FindObjectOfType<MusicControler>().PlayWrong();
        }
        SetRandomQuestionAnswer();
    }

    IEnumerator _DisplayMainPanel()
    {
        yield return new WaitForSeconds(timeBetweenTrans); //cho 3s cau hoi hien ra
        
        pnlQuestion.SetActive(true);

        if (turn <= 10)
            txtTurn.text = "Turn: " + turn.ToString();
    }
    public void _newTurn()
    {
        
        turn++;
        
        StartCoroutine(_DisplayMainPanel());//hien cau hoi ra moi ++turn
        
    }
    void Start()
    {
        _newTurn();
        if (unanswerQuestions == null || unanswerQuestions.Count == 0)
        {
            PlayerPrefs.SetInt("init", 0);
            InitQuestion();
            unanswerQuestions = questions.ToList<Questions>();
        }
        SetRandomQuestionAnswer();
    }

    private void SetRandomQuestionAnswer()
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
