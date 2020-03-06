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
    [SerializeField] Question.QuesData[] questions ;

    private static List<Question.QuesData> unansweredQuestions;

    Question.QuesData curQuestion;

    //Question.Questiondata 

    [SerializeField] float timeBetweenTransitions = 1f;

    [SerializeField] Text questionText;

    [SerializeField] Animator anmt;

    [SerializeField] GameObject firstStep;
    [SerializeField] GameObject secondStep;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject thirdStep;

    Question.Questiondata initQuesData;

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
        if (PlayerPrefs.GetInt("init") == 0)
        {
            Question initQues = GetComponent<Question>();
            initQuesData = initQues.InitQuestion();
            Question.Questiondata WriteQuesData = initQues.InitQuestion();
            int temp = initQuesData.objects.Length;

            int j = 0;

            for(int i = 0; i< temp; i++)
            {
                if(initQuesData.objects[i].Type == 2)
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
                if(initQuesData.objects[i].Type == 2)
                {
                    questions[j-1] = initQuesData.objects[i];
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

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            PlayerPrefs.SetInt("init", 0);
            InitQuestion();

            unansweredQuestions = questions.ToList<Question.QuesData>();
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
        yield return new WaitForSeconds(timeBetweenTransitions);
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
        if(curQuestion.CorrectAnswer == "Đúng")
        {
            PlayerPrefabConfigs.SetScore += 10;
            anmt.SetTrigger("trueRight");
            questionText.text = "Chính xác rồi bạn ơi ! khắc phục cái lỗi mà trong API Unity không được rồi . toString nhá ! nhưng vẫn méo hiểu tại sao lại không được luôn á@&$^**!*@$&@$@&(%$ !";
            StartCoroutine("TransitionToNextQuestion");
        }
        else
        {
            StartCoroutine(TransitionToWrongAnswer(1));
        }
    }

    public void UserSelectFalse()
    {
        if (curQuestion.CorrectAnswer == "Sai" )
        {
            PlayerPrefabConfigs.SetScore += 10;
            anmt.SetTrigger("falseTrue");
            questionText.text = "Chính xác!";
            //anmt.SetTrigger();
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
        questionText.text = "The Answer is ...";
        secondStep.SetActive(false);
        yield return new WaitForSeconds(timeBetweenTransitions);
        thirdStep.SetActive(true);
    }

    public void UserSelectBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
