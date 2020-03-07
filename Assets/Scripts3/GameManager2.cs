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
    [SerializeField] Question.QuesData[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] Text[] answer;

    static List<Question.QuesData> unanswerQuestions;

    Question.QuesData curQues;
    Question.Questiondata initQuesData;

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
        if (PlayerPrefs.GetInt("init") == 0)
        {
            Question initQues = GetComponent<Question>();
            initQuesData = initQues.InitQuestion();
            int temp = initQuesData.objects.Length;
            Debug.Log(temp);

            int j = 0;

            for (int i = 0; i < temp; i++)
            {
                if (initQuesData.objects[i].Type == 1)
                {
                    j++;
                }
            }

            questions = new Question.QuesData[j];
            //Debug.Log(initQuesData.objects[0].Text);

            //questions = new Questions[temp];
            for (int i = 0; i < temp; i++)
            {
                //Debug.Log(initQuesData.objects[i].Type);
                //Debug.Log(i);
                if (initQuesData.objects[i].Type == 1)
                {
                    questions[j - 1] = initQuesData.objects[i];
                    j--;
                }
                PlayerPrefs.SetInt("init", 1);
                //string a = initQuesData.objects[i].CorrectAnswer;
                //Debug.Log(a);           
                //WriteQuesData.objects[i].Text = initQuesData.objects[i].Text;
                //WriteQuesData.objects[i].CorrectAnswer = initQuesData.objects[i].CorrectAnswer;             
            }
            //string json = JsonUtility.ToJson(WriteQuesData);

            //File.WriteAllText(Application.dataPath + "/RemainQuestion.json", json);
            PlayerPrefs.SetInt("init", 1);
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
            unanswerQuestions = questions.ToList<Question.QuesData>();
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
