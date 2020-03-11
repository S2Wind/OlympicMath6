using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.IO;

//Tinh toan lai cach tinh diem cong cho game Ok 
public class GameManager4 : MonoBehaviour
{
    [SerializeField] Questions[] questions ;

    private static List<Questions> unansweredQuestions;

    Questions curQuestion;

    //Question.Questiondata 

    [SerializeField] float timeBetweenTransitions = 1f;

    [SerializeField] Text questionText;

    [SerializeField] Animator anmt;

    [SerializeField] GameObject firstStep;
    [SerializeField] GameObject secondStep;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject thirdStep;

    //Question.Questiondata initQuesData;

    private void Awake()
    {
        firstStep.SetActive(true);
        secondStep.SetActive(false);
        Wall.SetActive(false);
        thirdStep.SetActive(false);
        InitQuestion();
    }

    public void InitQuestion()
    {
        StartQuestion ques = FindObjectOfType<StartQuestion>();
        int j = 0;
        Debug.Log(ques.questions.Length);
        for(int i = 0;i < ques.questions.Length;i++)
        {
            if (ques.questions[i].Type == 2)
            {
                j++;
            }
        }
        questions = new Questions[j];
        for (int i = 0; i < ques.questions.Length; i++)
        {
            if (ques.questions[i].Type == 2)
            {
                questions[j-1] = ques.questions[i];
                j--;
            }
        }
    }

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            InitQuestion();

            unansweredQuestions = questions.ToList<Questions>();
        }
        SetRamdomQuestion();
    }

    private void SetRamdomQuestion()
    {
        int curQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        curQuestion = unansweredQuestions[curQuestionIndex];
        questionText.text = unansweredQuestions[curQuestionIndex].Text;
    }

   
    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(curQuestion);
        Wall.SetActive(true);
        FindObjectOfType<MusicControler>().PlayOther();
        yield return new WaitForSeconds(timeBetweenTransitions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //If Wrong Answer will take to this 
    IEnumerator TransitionToWrongAnswer(int i)
    {
        Wall.SetActive(true);
        if (i == 1)
            TrueSelection();
        else
            if (i == 2)
            FalseSelection();
        else
            UnsureSelection();
        questionText.text = "Sai mất rôi ??!";
        if (i != 3)
            FindObjectOfType<MusicControler>().PlayWrong();
        else
            FindObjectOfType<MusicControler>().PlayUnsure();
        yield return new WaitForSeconds(timeBetweenTransitions);
        questionText.text = curQuestion.Text;
        firstStep.SetActive(false);
        secondStep.SetActive(true);
        Wall.SetActive(false);
    }

    private void TrueSelection()
    {
        anmt.SetTrigger("trueWrong");
    }

    void FalseSelection()
    {
        anmt.SetTrigger("falseWrong");
    }

    void UnsureSelection()
    {
        anmt.SetTrigger("unsureRight");
    }



    // Lần sau nhớ tách các thuộc tính riêng nha :))
    public void UserSelectTrue()
    {
        if(curQuestion.CorrectAnswer.Length == 4)
        {
            PlayerPrefabConfigs.SetScore += 10;
            anmt.SetTrigger("trueRight");
            questionText.text = "Chính Xác!";
            FindObjectOfType<MusicControler>().PlayTrue();
            StartCoroutine("TransitionToNextQuestion");
            
        }
        else
        {
            StartCoroutine(TransitionToWrongAnswer(1));
        }
    }

    public void UserSelectFalse()
    {
        if (curQuestion.CorrectAnswer[0].ToString() == "S")
        {
            
            PlayerPrefabConfigs.SetScore += 10;
            anmt.SetTrigger("falseTrue");
            questionText.text = "Chính xác!";
            //anmt.SetTrigger();
            FindObjectOfType<MusicControler>().PlayTrue();
            StartCoroutine("TransitionToNextQuestion");
        }
        else
        {
            StartCoroutine(TransitionToWrongAnswer(2));
        }
    }

    public void UserSelectUnsure()
    {
        StartCoroutine(TransitionToWrongAnswer(3));
        //1 Repeat
        //2 Next Answer
    }

    public void UserSelectAgain()
    {
        StartCoroutine(AgainChoice());
    }

    IEnumerator AgainChoice()
    {
        yield return new WaitForSeconds(timeBetweenTransitions);
        secondStep.SetActive(false);
        firstStep.SetActive(true);
    }

    public void UserSelectShowAnwer()
    {
        StartCoroutine("ShowAnswer");
    }

    public void UserSelectNextQuestion()
    {
        StartCoroutine(TransitionToNextQuestion());
    }

    IEnumerator ShowAnswer()
    {
        FindObjectOfType<MusicControler>().PlayOther();
        questionText.text = "The Answer is ...";
        secondStep.SetActive(false);
        yield return new WaitForSeconds(timeBetweenTransitions);
        FindObjectOfType<MusicControler>().PlayUnsure();
        questionText.text = "Tự học là một đức tính tốt!";
        thirdStep.SetActive(true);
    }

    public void UserSelectBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
