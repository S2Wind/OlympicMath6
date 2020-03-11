using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] GameObject e;
    public Text txtdiem;
    
    
    public void MakeSure()
    {
        e.SetActive(true);
    }

    public void Cancel()
    {
        e.SetActive(false);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        if(txtdiem != null)
            txtdiem.text = "Điểm của bạn là: " + PlayerPrefabConfigs.GetDiem().ToString();
    }
}
