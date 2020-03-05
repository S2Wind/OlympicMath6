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
    [SerializeField] QuestionsOfGame2[] question;

    [SerializeField] TextMeshProUGUI ques;

    [SerializeField] TextMeshProUGUI[] answer;

    static List<QuestionsOfGame2> unanswerQuestions;

    QuestionsOfGame2 curQues;
    [Header("Some Configs")]
    [SerializeField] float timeBetweenTransition = 1f;

    [SerializeField] GameObject blockClicked;

    MainGameManager mainGameManager;
 
    void Start()
    {
        mainGameManager = GetComponent<MainGameManager>();
        ActivePanel();
        SetRandomQuestionAnswer();
    }

    private void SetRandomQuestionAnswer()
    {
        unanswerQuestions = question.ToList<QuestionsOfGame2>();
        int randomIndex = Random.Range(0, unanswerQuestions.Count);
        curQues = unanswerQuestions[randomIndex];
        ques.text = curQues.question;
        answer[0].text = curQues.answer1;
        answer[1].text = curQues.answer2;
        answer[2].text = curQues.answer3;
        answer[3].text = curQues.answer4;
    }

    public void CheckAsIfAnswerTrue()
    {
        StartCoroutine(WaitForAnswer());
    }
    

    IEnumerator WaitForAnswer()
    {
        AnswerPanelAnimationControl choice = FindObjectOfType<AnswerPanelAnimationControl>();
        choice.SetAnimation(StringAnswerChange());
        string a = GetComponent<WhatButtonIsPressed>().ButtonIHit();
        if (IntAnswerChange(a[0]) == curQues.trueAnswer)
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
        if (curQues.trueAnswer == 0)
        {
            a = "ATrue";
        }
        if (curQues.trueAnswer == 1)
        {
            a =  "BTrue";
        }
        if (curQues.trueAnswer == 2)
        {
            a = "CTrue";
        }
        if (curQues.trueAnswer == 3)
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
