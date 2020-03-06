using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] GameObject bodyPanel;

    [SerializeField] GameObject questionPanel;

    [SerializeField] GameObject answerPanel;

    [SerializeField] GameObject menu;

    [SerializeField] GameObject cuteThing;

    [SerializeField] GameObject gameManager;

    [SerializeField] GameObject guildPanel;

    [Header("Q/A")]
    [SerializeField] Question.QuesData[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] TextMeshProUGUI[] answer;

    static List<Question.QuesData> unanswerQuestions;

    Question.QuesData curQues;
    [Header("Some Configs")]
    [SerializeField] float timeBetweenTransition = 1f;

    [SerializeField] GameObject blockClicked;

    MainGameManager mainGameManager;

    Question.Questiondata initQuesData;

    private void Awake()
    {
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


    void Start()
    {
        mainGameManager = GetComponent<MainGameManager>();
        ActivePanel();
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

    //UPPPPPPP
    //
    //

    //

    public void CheckAsIfAnswerTrue()
    {
        StartCoroutine(WaitForAnswer());
    }
    

    IEnumerator WaitForAnswer()
    {
        AnswerPanelAnimationControl choice = FindObjectOfType<AnswerPanelAnimationControl>();
        choice.SetAnimation(StringAnswerChange());
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        if (a[0].ToString() == curQues.CorrectAnswer)
        {
            ques.text = "Chính Xác";
            blockClicked.gameObject.SetActive(false);
        }
        else
        {
            blockClicked.GetComponent<Image>().color = Color.red;
            blockClicked.GetComponent<Block>().SetIsAnswered = true;
            ques.text = "Sai mất rồi!";
        }
        yield return new WaitForSeconds(timeBetweenTransition);
        ActivePanel();
    }


    private string StringAnswerChange()
    {
        string a = null;
        if (curQues.CorrectAnswer == "A")
        {
            a = "ATrue";
        }
        if (curQues.CorrectAnswer == "B")
        {
            a =  "BTrue";
        }
        if (curQues.CorrectAnswer == "C")
        {
            a = "CTrue";
        }
        if (curQues.CorrectAnswer == "D")
        {
            a = "DTrue";
        }
        return a;
    }

    int IntAnswerChange(char a)
    {
        if (a == 'A')
            return 0;
        else
            if (a == 'B')
            return 1;
        else
            if (a == 'C')
            return 2;
        else
            if(a == 'D')
            return 3;
        return 0;
    }

    public void ActivePanel()
    {
        
            bodyPanel.SetActive(true);
            questionPanel.SetActive(false);
            answerPanel.SetActive(false);
        menu.SetActive(true);
        gameManager.SetActive(true);
        cuteThing.SetActive(true);
    }

    public void ActiveQuestionPanel()
    {
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        blockClicked = GameObject.Find(a[0].ToString());
        if (!blockClicked.GetComponent<Block>().GetIsAnswered())
        {
            bodyPanel.SetActive(false);
            questionPanel.SetActive(true);
            answerPanel.SetActive(true);
            SetRandomQuestionAnswer();
        }
    }


    public void UserSelectReturnButton()
    {
        Debug.Log("Back To Menu");
    }

    public void UserSelectMusicButton()
    {
        Debug.Log("Music On");
    }

    public void UserSelectDesciption()
    {
        guildPanel.SetActive(true);
        menu.SetActive(false);
        cuteThing.SetActive(false);
        bodyPanel.SetActive(false);
        questionPanel.SetActive(false);
        answerPanel.SetActive(false);
        gameManager.SetActive(false);
    }
}
