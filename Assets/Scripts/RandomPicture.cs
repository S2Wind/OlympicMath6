using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RandomPicture : MonoBehaviour
{
    [SerializeField] Sprite[] pictures;

    static List<Sprite> unusedPicture;

    Image curPicture;
    //Instiatiate Picture
    private void Start()
    {
        unusedPicture = pictures.ToList<Sprite>();
        curPicture = GetComponent<Image>();
        int randomIndex = Random.Range(0, unusedPicture.Count);
        curPicture.sprite = unusedPicture[randomIndex];
    }

    //Remove which is used
    //Appear Question When Click
    public void ShowQuestion()
    {

    }

}
