using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SecondSetText : MonoBehaviour
{
    [SerializeField] Text again;
    [SerializeField] Text show;
    void Start()
    {
        again.text = "Làm lại!";
        show.text = "Bỏ cuộc???!";
    }
}
