using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float moveSpeed;
    private GameObject obj;

    void Start()
    {
        obj = gameObject;
        moveSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager1>().isPause == false)
            obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
        
    }
}
