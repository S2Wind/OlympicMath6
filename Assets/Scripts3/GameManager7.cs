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
    [SerializeField] Question.QuesData[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] Text[] answer;

    static List<Question.QuesData> unanswerQuestions;

    Question.QuesData curQues;
    Question.Questiondata initQuesData;
    private void Awake()
    {
        FindObjectOfType<Clock4>().SetClock(20, 0);
        InitQuestion();
    }

    public void InitQuestion()
    {
        if (PlayerPrefs.GetInt("init") == 0)
        {
            Question initQues = GetComponent<Question>();
            initQuesData = initQues.InitQuestion();
            int temp = initQuesData.objects.Length;


            int j = 0;

            for (int i = 0; i < temp; i++)
            {
                if (initQuesData.objects[i].Type == 1)
                {
                    j++;
                }
            }

            Debug.Log(j);
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
        SceneManager.LoadScene("endgame3");
    }

    public void CheckIfItTrueOrNot()
    {
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        Debug.Log(a);
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
        SetRandomQuestionAnswer();

    }
    void Start()
    {
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
