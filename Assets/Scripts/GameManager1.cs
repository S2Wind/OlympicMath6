using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    [Header("Q/A")]
    [SerializeField] Questions[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] Text[] answer;

    static List<Questions> unanswerQuestions;

    Questions curQues;

    public int turn = 0;
    public Text txtturn;

    public int point = 0;
    public Text txtpoint;

    public GameObject pnlQuestion;
    
    public bool isPause = false;

    
    private void Awake()
    {
        InitQuestion();
        FindObjectOfType<Clock1>().SetClock(20,1 );
    }

    public void TimeOut()
    {
        SceneManager.LoadScene("endgame1");
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

    public void CheckIfItTrueOrNot()
    {
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        Debug.Log(a);
        if(a[0].ToString() == curQues.CorrectAnswer)
        {
            FindObjectOfType<EventButton>()._Accepted();
            FindObjectOfType<MusicControler>().PlayTrue();
            if (PlayerPrefs.GetInt("high1") < point)
                PlayerPrefs.SetInt("high1", point);
        }
        else
        {
            FindObjectOfType<EventButton>()._Wrong();
            FindObjectOfType<MusicControler>().PlayWrong();
        }
        SetRandomQuestionAnswer();

    }

    IEnumerator _DisplayMainPanel()
    {
        yield return new WaitForSeconds(5); //thoi gian nho se là turn + 1
        
        isPause = true;

        txtturn.text = "Turn: " + turn.ToString();

        yield return new WaitForSeconds(0.5f);//0.5s sau hien ra cau hoi
        
        pnlQuestion.SetActive(true);
    }
    public void _newTurn()
    {
        turn += 1;
        

        StartCoroutine(_DisplayMainPanel());
    }
    void Start()
    {
        _newTurn();
        if (unanswerQuestions == null || unanswerQuestions.Count == 0)
        {
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

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
