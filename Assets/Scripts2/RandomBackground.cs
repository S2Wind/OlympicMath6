using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] Texture[] pictures;

    RawImage curPic;

    void Start()
    {
        curPic = GetComponent<RawImage>();

        int randomIndex = Random.Range(0, pictures.Length);

        curPic.texture = pictures[randomIndex];
    }

}
