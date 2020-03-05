using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [Header("Block")]
    [SerializeField] GameObject[] blocks;

    [Header("GameManager")]
    GameManager3 gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager3>();
    }
}
