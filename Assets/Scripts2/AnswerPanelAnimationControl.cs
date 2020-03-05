using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanelAnimationControl : MonoBehaviour
{
    Animator anmt;
    public void SetAnimation(string a)
    {
        anmt = GetComponent<Animator>();
        anmt.SetTrigger(a);
    }
}
