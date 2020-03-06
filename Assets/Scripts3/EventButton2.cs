using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton2 : MonoBehaviour
{
    public GameObject iconAC;
    
    public GameObject iconWrong;

    public GameObject ga1;
    public GameObject ga2;
    public GameObject ga3;
    public GameObject ga4;
    public GameObject ga5;
    public GameObject ga6;
    public GameObject ga7;
    public GameObject ga8;
    public GameObject ga9;
    public GameObject ga10;
    public float timeBetweenTrans = 1.9f;

    public void _btnAC()
    {
        FindObjectOfType<GameManager2>().point += 10;
        FindObjectOfType<GameManager2>().txtPoint.text = "Point: " + FindObjectOfType<GameManager2>().point.ToString();


        FindObjectOfType<GameManager2>().pnlQuestion.SetActive(false);
        iconAC.SetActive(true);
        StartCoroutine(_AC());//cho 2s r an di


        if (FindObjectOfType<GameManager2>().turn == 1)
            ga1.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 2)
            ga2.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 3)
            ga3.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 4)
            ga4.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 5)
            ga5.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 6)
            ga6.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 7)
            ga7.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 8)
            ga8.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 9)
            ga9.SetActive(true);
        else if (FindObjectOfType<GameManager2>().turn == 10)
        {
            ga10.SetActive(true);
            StartCoroutine( _EndGame() );
        }
        
        
        if(FindObjectOfType<GameManager2>().turn < 10)
            FindObjectOfType<GameManager2>()._newTurn();//goi luot choi moi
    }
    IEnumerator _AC()
    {
        yield return new WaitForSeconds(timeBetweenTrans); //cho 2s

        iconAC.SetActive(false);
    }
    IEnumerator _EndGame()
    {
        yield return new WaitForSeconds(timeBetweenTrans); //cho 3s
        Application.LoadLevel("endgame2");
    }

    public void _Wrong()
    {
        FindObjectOfType<GameManager2>().pnlQuestion.SetActive(false);
        iconWrong.SetActive(true);
        StartCoroutine(_Wr());//cho 1.5s r an di

        if (FindObjectOfType<GameManager2>().turn < 10)
            FindObjectOfType<GameManager2>()._newTurn();//goi luot choi moi
        else if (FindObjectOfType<GameManager2>().turn == 10)//cau cuoi sai thi endgame luon
        {
            StartCoroutine(_EndGame());
        }
    }
    IEnumerator _Wr()
    {
        yield return new WaitForSeconds(2); //cho 1.5s

        iconWrong.SetActive(false);
    }
    public void _StartGame()
    {
        Application.LoadLevel("gameplay2");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
