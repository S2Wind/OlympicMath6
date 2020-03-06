using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] bool isAnswered = false ;
    public bool GetIsAnswered()
    {
        return isAnswered;
    }

    public bool SetIsAnswered
    { get { return isAnswered; }
        set { isAnswered = value; }
            }
}
