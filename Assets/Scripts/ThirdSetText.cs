using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThirdSetText : MonoBehaviour
{
    [SerializeField] Text text;

    void Start()
    {
        text.text = "Tiếp tục nào!!!";
    }

}
