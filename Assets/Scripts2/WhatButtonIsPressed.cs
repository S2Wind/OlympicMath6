using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhatButtonIsPressed : MonoBehaviour
{
    public string ButtonIHit()
    {
        string a = null;
        int layerMask = (1<<9);
        RaycastHit2D whatIHit = Physics2D.Raycast(MousePosition(),new Vector2(0,0),layerMask);
        Debug.DrawRay(new Vector2(0, 0), new Vector2(0, 0));
        if (whatIHit.collider != null)
        {
            a = whatIHit.collider.name;
            Debug.Log(a);
        }
        return a;
    }

    Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
