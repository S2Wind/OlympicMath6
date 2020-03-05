using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    
    public int turn = 0;
    public Text txtTurn;

    public int point = 0;
    public Text txtPoint;

    public GameObject pnlQuestion;
    IEnumerator _DisplayMainPanel()
    {
        yield return new WaitForSeconds(3); //cho 3s cau hoi hien ra
        
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

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
