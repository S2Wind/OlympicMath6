using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveSpeed = 2;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject obj;

    public void _HideFish()
    {
        gameObject.SetActive(false);
        FindObjectOfType<EventButton3>()._OnClickFish();
    }

    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        
        moveRange = 22;
    }
    void Update()
    {
        if(oldPosition.x < 0)//neu ban dau bang o ben trai thi di sang phai
            obj.transform.Translate(new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0));
        else//neu ban dau dang o ben phai thi di sang trai
            obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
