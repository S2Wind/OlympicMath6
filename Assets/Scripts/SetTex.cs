using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTex : MonoBehaviour
{
    [SerializeField] Text trueText;
    [SerializeField] Text falseText;
    [SerializeField] Text unSureText;
    void Start()
    {
        trueText.text = "Đúng";
        falseText.text = "Sai";
        unSureText.text = "Không chắc";
    }

}
