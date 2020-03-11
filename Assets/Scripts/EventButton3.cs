using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButton3 : MonoBehaviour
{
    public int soluongFish = 0;
    public int point = 0;
    public Text txtPoint;

    public GameObject pnlQuestion;
    public GameObject iconAC;
    public GameObject iconWr;

    public GameObject btnAnswerA;
    public GameObject btnAnswerB;
    public GameObject btnAnswerC;
    public GameObject btnAnswerD;

    public void _OnClickFish()
    {
        soluongFish++;
        
        pnlQuestion.SetActive(true);
        btnAnswerA.SetActive(true);
        btnAnswerB.SetActive(true);
        btnAnswerC.SetActive(true);
        btnAnswerD.SetActive(true);
        //van chua an dc con ca day di, khi nhan vao con ca nao thi n se bj an di luon


    }
    public void _AC()
    {
        point += 10;
        txtPoint.text = "Point: " + point.ToString();
        if (point > PlayerPrefs.GetInt("high3"))
            PlayerPrefs.SetInt("high3", point);

        btnAnswerA.SetActive(false);
        btnAnswerB.SetActive(false);
        btnAnswerC.SetActive(false);
        btnAnswerD.SetActive(false);

        iconAC.SetActive(true);

        StartCoroutine(_DisplayIconAC());
    }
    IEnumerator _DisplayIconAC()
    {
        yield return new WaitForSeconds(2); //cho 2s thi tat
        iconAC.SetActive(false);
        pnlQuestion.SetActive(false);
        if (soluongFish == 12 || point == 100)
        {
            PlayerPrefabConfigs.SetDiem = point;
            yield return new WaitForSeconds(1);
            Application.LoadLevel("endgame3"); //dieu kien de endgame
        }
    }

    public void _Wr()
    {
        btnAnswerA.SetActive(false);
        btnAnswerB.SetActive(false);
        btnAnswerC.SetActive(false);
        btnAnswerD.SetActive(false);

        iconWr.SetActive(true);

        StartCoroutine(_DisplayIconWr());
    }
    IEnumerator _DisplayIconWr()
    {
        yield return new WaitForSeconds(2); //cho 2s thi tat
        iconWr.SetActive(false);
        pnlQuestion.SetActive(false);

        PlayerPrefabConfigs.SetDiem = point;
        if (soluongFish == 12 || point == 100)
        {
            PlayerPrefabConfigs.SetDiem = point;
            yield return new WaitForSeconds(1);
            Application.LoadLevel("endgame3"); //dieu kien de endgame
        }
            
    }

    public void _StartGame()
    {
        Application.LoadLevel("gameplay3");
    }


}
