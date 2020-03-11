using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] GameObject ExitPanel;

    [SerializeField] GameObject Panel;

    [SerializeField] Block[] blockArr;
    [Header("Q/A")]
    [SerializeField] Questions[] questions;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] TextMeshProUGUI[] answer;

    static List<Questions> unanswerQuestions;

    Questions curQues;

    [Header("Some Configs")]
    [SerializeField] float timeBetweenTransition = 1f;

    [SerializeField] Block blockClicked;

    [SerializeField] TextMeshProUGUI scoreText;
 


    int score;
    int blockLeft;
    int c = 0;

    public int GetScore()
    {
        return score;
    }

    public void SetScore()
    {
        scoreText.text = "Bạn đạt được :\n"+ score.ToString();
    }

    private void Awake()
    {
        ActivePanel();
        FindObjectOfType<Clocks>().SetClock(10,1);
        InitQuestion();
        blockLeft = 9;
        c = 0;
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


    void Start()
    {
        for (int i = 0; i < blockArr.Length; i++)
        {
            blockArr[i].SetIsAnswered = false;
        }
        if (unanswerQuestions == null || unanswerQuestions.Count == 0)
        {
            InitQuestion();
            unanswerQuestions = questions.ToList<Questions>();
        }
        SetRandomQuestionAnswer();
    }

    public void TimeOut()
    {
        if(FindObjectOfType<Clocks>().timeOver)
            StartCoroutine(WaitToSeePicture());
    }
    

    public void GameControlBlock()
    {  
        if (blockLeft == 0)
        {
            StartCoroutine(WaitToSeePicture());
        }
    }

    IEnumerator WaitToSeePicture()
    {
        ActivePanel();
        if (c == 9)
            yield return new WaitForSeconds(timeBetweenTransition + 9f);
        else
            yield return new WaitForSeconds(timeBetweenTransition);
        StartCoroutine(ReStart());
    }



    IEnumerator ReStart()
    {
        PlayerPrefs.SetInt("score5", PlayerPrefs.GetInt("score5") + c * 5);
        score += c * 5;
        if (c == 9)
        {
            score += 50;
            PlayerPrefs.SetInt("score5", PlayerPrefs.GetInt("score5") + 50);
        }
        End1Round();
        SetScore();
        yield return new WaitForSeconds(timeBetweenTransition+2f);
        SceneManager.LoadScene("Game5");
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

    public void CheckAsIfAnswerTrue()
    {
        StartCoroutine(SetWall());
        StartCoroutine(WaitForAnswer());
    }
    
    IEnumerator SetWall()
    {
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().enabled = false;
        yield return new WaitForSeconds(timeBetweenTransition + 0.1f);
        FindObjectOfType<UnityEngine.EventSystems.EventSystem>().enabled = true;
    }

    IEnumerator WaitForAnswer()
    {
        blockLeft--;
        AnswerPanelAnimationControl choice = FindObjectOfType<AnswerPanelAnimationControl>();
        choice.SetAnimation(curQues.CorrectAnswer+"True");
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        if (a[0].ToString() == curQues.CorrectAnswer)
        {
            ques.text = "Chính Xác";
            FindObjectOfType<MusicControler>().PlayTrue();
            blockClicked.gameObject.SetActive(false);
            PlayerPrefs.SetInt("score5", PlayerPrefs.GetInt("score5") + 10);
            score += 10;
            c++;
        }
        else
        {
            blockClicked.GetComponent<Image>().color = Color.red;
            PlayerPrefs.SetInt("score5", PlayerPrefs.GetInt("score5") - 5);
            score -= 5;
            ques.text = "Sai mất rồi!";
            FindObjectOfType<MusicControler>().PlayWrong();
        }
        blockClicked.GetComponent<Block>().SetIsAnswered = true;
        yield return new WaitForSeconds(timeBetweenTransition);
        ActivePanel();
        GameControlBlock();
    }


    public void ActivePanel()
    {
        bodyPanel.SetActive(true);
        questionPanel.SetActive(false);
        answerPanel.SetActive(false);
        menu.SetActive(true);
        gameManager.SetActive(true);
        cuteThing.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void ActiveQuestionPanel()
    {
        StartCoroutine(SetWall());
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        FindObjectOfType<MusicControler>().PlayOther();
        for(int i = 0; i <blockArr.Length;i++)
        {
            if (blockArr[i].name == a)
                blockClicked = blockArr[i];
        }
        if (!blockClicked.GetIsAnswered())
        {
            bodyPanel.SetActive(false);
            questionPanel.SetActive(true);
            answerPanel.SetActive(true);
            SetRandomQuestionAnswer();
        }
    }


    public void UserSelectReturnButton()
    {
        bodyPanel.SetActive(false);
        questionPanel.SetActive(false);
        answerPanel.SetActive(false);
        menu.SetActive(false);
        gameManager.SetActive(false);
        cuteThing.SetActive(false);
        ExitPanel.SetActive(true);
    }

    public void UserSelectCancel()
    {
        bodyPanel.SetActive(true);
        menu.SetActive(true);
        gameManager.SetActive(true);
        cuteThing.SetActive(true);
        ExitPanel.SetActive(false);
    }

    public void UserSelectReturnMenu()
    {
        SceneManager.LoadScene(0);
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

    public void UserSelectDone()
    {
        guildPanel.SetActive(false);
        bodyPanel.SetActive(true);
        menu.SetActive(true);
        gameManager.SetActive(true);
        cuteThing.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void End1Round()
    {
        bodyPanel.SetActive(false);
        Panel.SetActive(true);
    }

    public void StartRound()
    {
        bodyPanel.SetActive(true);
        Panel.SetActive(false);
    }
}
