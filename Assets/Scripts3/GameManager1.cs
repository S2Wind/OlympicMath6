using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public int turn = 0;
    public Text txtturn;

    public int point = 0;
    public Text txtpoint;

    public GameObject pnlQuestion;
    
    public bool isPause = false;

    

    IEnumerator _DisplayMainPanel()
    {
        yield return new WaitForSeconds(5); //thoi gian nho se là turn + 1
        
        isPause = true;

        txtturn.text = "Turn: " + turn.ToString();

        yield return new WaitForSeconds(0.5f);//0.5s sau hien ra cau hoi
        
        pnlQuestion.SetActive(true);
    }
    public void _newTurn()
    {
        turn += 1;
        

        StartCoroutine(_DisplayMainPanel());
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
