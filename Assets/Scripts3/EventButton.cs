using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour
{
    public GameObject cnv1;
    public GameObject cnv2;
    public GameObject cnv3;
    public GameObject cnv4;
    public GameObject cnv5;

    
    public GameObject iconAC;
    public GameObject iconWrong;

    private int dem1 = 0, dem2 = 0, dem3 = 0, dem4 = 0, dem5 = 0;

    public void _Accepted()
    {
        FindObjectOfType<GameManager1>().pnlQuestion.SetActive(false);
        FindObjectOfType<GameManager1>().isPause = false;
        FindObjectOfType<GameManager1>().point += 20;
        FindObjectOfType<GameManager1>().txtpoint.text = "Point: " + FindObjectOfType<GameManager1>().point;

        if (FindObjectOfType<GameManager1>().point == 20)
            cnv1.SetActive(false);
        else if(FindObjectOfType<GameManager1>().point == 40)
            cnv2.SetActive(false);
        else if (FindObjectOfType<GameManager1>().point == 60)
            cnv3.SetActive(false);
        else if (FindObjectOfType<GameManager1>().point == 80)
            cnv4.SetActive(false);
        else if (FindObjectOfType<GameManager1>().point == 100)
            cnv5.SetActive(false);

        iconAC.SetActive(true);
        StartCoroutine(_AC());//cho 2s r an di

        if (FindObjectOfType<GameManager1>().point < 100)
            FindObjectOfType<GameManager1>()._newTurn();
        else
            StartCoroutine(_WinGame());
    }
    IEnumerator _AC()
    {


        yield return new WaitForSeconds(2); //cho 5s

        iconAC.SetActive(false);
    }
    IEnumerator _WinGame()
    {
        yield return new WaitForSeconds(5); //cho 5s de hien thi man hinh wingame

        Application.LoadLevel("endgame1");
    }

    

    public void _Wrong()
    {
        FindObjectOfType<GameManager1>().pnlQuestion.SetActive(false);
        FindObjectOfType<GameManager1>().isPause = true;

        //sai thi ko dc cong diem
        iconWrong.SetActive(true);

        if (FindObjectOfType<GameManager1>().turn == 1)
            dem1++;
        else if (FindObjectOfType<GameManager1>().turn == 2)
            dem2++;
        else if (FindObjectOfType<GameManager1>().turn == 3)
            dem3++;
        else if (FindObjectOfType<GameManager1>().turn == 4)
            dem4++;
        else if (FindObjectOfType<GameManager1>().turn == 5)
            dem5++;

        if(dem1 == 3 || dem2 == 3 || dem3 == 3 || dem4 == 3 || dem5 == 3)//dieu kien sai 3 cau lien tiep thi ket thuc
            StartCoroutine(_EndGame());

        StartCoroutine(_Wr());//cho 1.5s roi hien cau moi
    }
    IEnumerator _Wr()
    {
        yield return new WaitForSeconds(1.5f); //cho 1.5s

        iconWrong.SetActive(false);

        FindObjectOfType<GameManager1>().pnlQuestion.SetActive(true);
    }
    IEnumerator _EndGame()
    {
        yield return new WaitForSeconds(1); //cho 1s endgame

        Application.LoadLevel("endgame1");// ve sau doi thanh man hinh endgame // tam thoi de man hinh nay da
    }
    public void _StartGame()
    {
        Application.LoadLevel("gameplay1");
    }
    

}
